using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using scoreoracle_backend.DTOs.Pick;
using scoreoracle_backend.Models;

namespace scoreoracle_backend.Mappers
{
    public class PickMapper
    {
        public static PickResponseDto MapToDto(
            Pick pick,
            User user,
            Group group,
            Game game,
            Team awayTeam,
            Team homeTeam,
            Team predictedWinnerTeam
        )
        {
            return new PickResponseDto
            {
                Id = pick.Id,
                UserId = pick.UserId,
                Username = user.Username,
                GroupId = pick.GroupId,
                GroupName = group.Name,
                GameId = pick.GameId,
                AwayTeamId = game.AwayTeamId,
                AwayTeamCity = awayTeam.CityName,
                AwayTeamName = awayTeam.Name,
                HomeTeamId = game.HomeTeamId,
                HomeTeamCity = homeTeam.CityName,
                HomeTeamName = homeTeam.Name,
                PredictedWinnerId = pick.PredictedWinnerId,
                PredictedTeamCity = predictedWinnerTeam.CityName,
                PredictedWinnerTeamName = predictedWinnerTeam.Name,
                GameDate = game.GameDate,
                IsCorrect = pick.IsCorrect,
                CreatedAt = pick.CreatedAt
            };
        }

        public static Pick MapToModel(PickRequestDto dto)
        {
            return new Pick
            {
                UserId = dto.UserId,
                GroupId = dto.GroupId,
                GameId = dto.GameId,
                PredictedWinnerId = dto.PredictedWinnerId
            };
        }

        public static void MapToUpdatedModel(Pick pick, UpdatePickDto dto)
        {
            if (dto.PredictedWinnerId != Guid.Empty && dto.PredictedWinnerId != pick.PredictedWinnerId)
            {
                pick.PredictedWinnerId = dto.PredictedWinnerId;
            }
        }

    }
}