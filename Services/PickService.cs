using scoreoracle_backend.DTOs.Pick;
using scoreoracle_backend.Interfaces;
using scoreoracle_backend.Mappers;
using scoreoracle_backend.Models;

public class PickService
{
    private readonly IPickRepository _repo;
    private readonly IUserRepository _userRepo;
    private readonly IGroupRepository _groupRepo;
    private readonly IGameRepository _gameRepo;
    private readonly ITeamRepository _teamRepo;
    private readonly IGroupMemberRepository _groupMemberRepo;

    public PickService(IPickRepository repo, IUserRepository userRepo, IGroupRepository groupRepo, IGameRepository gameRepo, ITeamRepository teamRepo, IGroupMemberRepository groupMemberRepo)
    {
        _repo = repo;
        _userRepo = userRepo;
        _groupRepo = groupRepo;
        _gameRepo = gameRepo;
        _teamRepo = teamRepo;
        _groupMemberRepo = groupMemberRepo;
    }

    public async Task<PickResponseDto> CreatePick(PickRequestDto dto, Guid currentUserId)
    {
        var isMember = await _groupMemberRepo.IsUserInGroup(dto.UserId, dto.GroupId);
        if(!isMember)
            throw new UnauthorizedAccessException("User is not a member of this group");
        
        var existingPick = await _repo.GetPickByUserAndGame(dto.UserId, dto.GameId);
        if(existingPick != null)
            throw new InvalidOperationException("A pick already exists for this game and user.");

        var group = await _groupRepo.GetGroupById(dto.GroupId);
        var game = await _gameRepo.GetGameById(dto.GameId);
        if(group.LeagueId != game.LeagueId)
            throw new InvalidOperationException("This game in not part of the group's league");

        if (dto.PredictedWinnerId != game.HomeTeamId && dto.PredictedWinnerId != game.AwayTeamId)
            throw new InvalidOperationException("Predicted team must be one of the teams playing in the game.");

        var pick = PickMapper.MapToModel(dto);
        if (pick.UserId != currentUserId)
            throw new UnauthorizedAccessException("You are not allowed to create this pick.");

        var created = await _repo.CreatePick(pick);
        return await MapPickToResponseDto(created);
    }

    public async Task<PickResponseDto?> GetPickById(Guid id)
    {
        var pick = await _repo.GetPickById(id);
        if (pick == null) return null;

        return await MapPickToResponseDto(pick);
    }

    public async Task<List<PickResponseDto>> GetAllPicks()
    {
        var picks = await _repo.GetAllPicks();
        var results = new List<PickResponseDto>();

        foreach (var pick in picks)
        {
            results.Add(await MapPickToResponseDto(pick));
        }

        return results;
    }

    public async Task<List<PickResponseDto>> GetPicksByUserId(Guid userId)
    {
        var picks = await _repo.GetPicksByUserId(userId);
        return await MapPickList(picks);
    }

    public async Task<List<PickResponseDto>> GetPicksByGroupId(Guid groupId)
    {
        var picks = await _repo.GetPicksByGroupId(groupId);
        return await MapPickList(picks);
    }

    public async Task<List<PickResponseDto>> GetPicksByUserAndGroup(Guid userId, Guid groupId)
    {
        var picks = await _repo.GetPicksByUserAndGroup(userId, groupId);
        return await MapPickList(picks);
    }

    public async Task<PickResponseDto?> UpdatePick(Guid id, UpdatePickDto dto, Guid currentUserId)
    {
        var pick = await _repo.GetPickById(id);
        if (pick == null) return null;

        if (pick.UserId != currentUserId)
            throw new UnauthorizedAccessException("You are not allowed to update this pick.");

        var game = await _gameRepo.GetGameById(pick.GameId);
        if (game == null) throw new InvalidOperationException("Game not found.");

        if (dto.PredictedWinnerId != game.HomeTeamId && dto.PredictedWinnerId != game.AwayTeamId)
            throw new InvalidOperationException("Predicted team must be one of the teams playing in the game.");

        pick.PredictedWinnerId = dto.PredictedWinnerId;
        var updated = await _repo.UpdatePick(pick);

        var isMember = await _groupMemberRepo.IsUserInGroup(updated.UserId, pick.GroupId);
        if (!isMember)
            throw new UnauthorizedAccessException("User is not authorized to modify this pick.");

        return await MapPickToResponseDto(updated);
    }

    public async Task<bool> DeletePick(Guid id, Guid currentUserId)
    {
        var pick = await _repo.GetPickById(id);
        if (pick == null) return false;
        if (pick.UserId != currentUserId)
            throw new UnauthorizedAccessException("You are not allowed to delete this pick.");

        var isMember = await _groupMemberRepo.IsUserInGroup(pick.UserId, pick.GroupId);
        if (!isMember)
            throw new UnauthorizedAccessException("User is not authorized to modify this pick.");

        await _repo.DeletePick(pick);
        return true;
    }

    

    private async Task<PickResponseDto> MapPickToResponseDto(Pick pick)
    {
        var user = await _userRepo.GetUserById(pick.UserId);
        var group = await _groupRepo.GetGroupById(pick.GroupId);
        var game = await _gameRepo.GetGameById(pick.GameId);
        var awayTeam = await _teamRepo.GetTeamById(game.AwayTeamId);
        var homeTeam = await _teamRepo.GetTeamById(game.HomeTeamId);
        var predictedWinner = await _teamRepo.GetTeamById(pick.PredictedWinnerId);

        return PickMapper.MapToDto(pick, user!, group!, game!, awayTeam!, homeTeam!, predictedWinner!);
    }

    private async Task<List<PickResponseDto>> MapPickList(List<Pick> picks)
    {
        var list = new List<PickResponseDto>();
        foreach (var pick in picks)
        {
            list.Add(await MapPickToResponseDto(pick));
        }
        return list;
    }
}
