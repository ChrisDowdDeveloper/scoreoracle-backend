# ScoreOracle API Documentation

This document outlines the available API routes grouped by controller, including route paths, methods, descriptions, and auth requirements. Request and response body examples are also provided where applicable.

---

## AuthController

### `POST /api/auth/create`

**Description:** Create a user profile after Supabase auth.
**Auth Required:** Yes (Bearer Token)
**Request Body:**

```json
{
  "username": "string",
  "email": "string"
}
```

### `POST /api/auth/signin`

**Description:** Sign in and retrieve user info using Supabase token.
**Auth Required:** Yes (Bearer Token)

---

## GameController

### `GET /api/game`

Get all games.

### `GET /api/game/team/{teamId}`

Get games by team ID.

### `GET /api/game/sport/{sportId}`

Get games by sport ID.

### `GET /api/game/league/{leagueId}`

Get games by league ID.

### `GET /api/game/league/{leagueId}/date?date=YYYY-MM-DD`

Get games by league and date.

### `GET /api/game/range?startDate=YYYY-MM-DD&endDate=YYYY-MM-DD`

Get games within date range.

### `GET /api/game/team/{teamId}/date?date=YYYY-MM-DD`

Get games by team and date.

### `GET /api/game/team/home/{homeTeamId}`

Get games where team is home.

### `GET /api/game/team/away/{awayTeamId}`

Get games where team is away.

### `GET /api/game/upcoming`

Get all upcoming games.

### `GET /api/game/completed`

Get all completed games.

### `GET /api/game/paged?pageNumber=1&pageSize=10`

Get paginated games.

### `GET /api/game/{id}`

Get a game by ID.

### `POST /api/game`

Create a game.
**Auth Required:** Yes
**Request Body:**

```json
{
  "homeTeamId": "guid",
  "awayTeamId": "guid",
  "gameDate": "2025-05-10"
}
```

### `PATCH /api/game/{id}`

Update a game.
**Auth Required:** Yes

### `DELETE /api/game/{id}`

Delete a game.
**Auth Required:** Yes

---

## GroupController

### `GET /api/group?pageNumber=1&pageSize=10`

List all groups.

### `GET /api/group/{id}`

Get a group by ID.
**Auth Required:** Yes

### `GET /api/group/public-groups`

List public groups.

### `GET /api/group/user/{userId}`

Get groups created by user.
**Auth Required:** Yes

### `GET /api/group/group-name/{keyword}`

Search groups by name keyword.

### `POST /api/group`

Create a group.
**Auth Required:** Yes

### `PATCH /api/group/{id}`

Update a group.
**Auth Required:** Yes

### `DELETE /api/group/{id}`

Delete a group.
**Auth Required:** Yes

---

## GroupMemberController

### `POST /api/groupmember`

Add a group member.
**Auth Required:** Yes

### `GET /api/groupmember/{id}`

Get group member by ID.
**Auth Required:** Yes

### `GET /api/groupmember/user/{userId}/group/{groupId}`

Get group member by user and group.
**Auth Required:** Yes

### `GET /api/groupmember/group/{groupId}/members`

List members by group.
**Auth Required:** Yes

### `GET /api/groupmember/group/{groupId}/admins`

List group admins.
**Auth Required:** Yes

### `PATCH /api/groupmember/{id}`

Update group member.
**Auth Required:** Yes

### `DELETE /api/groupmember/{id}`

Remove group member by ID.
**Auth Required:** Yes

### `DELETE /api/groupmember/user/{userId}/group/{groupId}`

Remove member by user and group.
**Auth Required:** Yes

### `GET /api/groupmember/user/{userId}/group/{groupId}/is-member`

Check if user is in group.

### `GET /api/groupmember/user/{userId}/group/{groupId}/is-admin`

Check if user is admin.
**Auth Required:** Yes

---

## LeagueController

### `GET /api/league`

Get all leagues.

### `GET /api/league/{id}`

Get league by ID.

### `GET /api/league/name/{name}`

Get league by name.

### `GET /api/league/sport/{sportId}`

Get leagues by sport.

### `POST /api/league`

Create league.
**Auth Required:** Yes

### `PATCH /api/league/{id}`

Update league.
**Auth Required:** Yes

### `DELETE /api/league/{id}`

Delete league.
**Auth Required:** Yes

---

## PickController

### `POST /api/pick`

Create pick.
**Auth Required:** Yes

### `GET /api/pick`

Get all picks.
**Auth Required:** Yes

### `GET /api/pick/{id}`

Get pick by ID.
**Auth Required:** Yes

### `GET /api/pick/user/{userId}`

Get picks by user.
**Auth Required:** Yes

### `GET /api/pick/group/{groupId}`

Get picks by group.
**Auth Required:** Yes

### `GET /api/pick/user/{userId}/group/{groupId}`

Get picks by user and group.
**Auth Required:** Yes

### `GET /api/pick/game/{gameId}`

Get picks by game.
**Auth Required:** Yes

### `GET /api/pick/group/{groupId}/leaderboard`

Get leaderboard by group.
**Auth Required:** Yes

### `PATCH /api/pick/{id}`

Update pick.
**Auth Required:** Yes

### `DELETE /api/pick/{id}`

Delete pick.
**Auth Required:** Yes

---

## SportController

### `GET /api/sport`

Get all sports.

### `GET /api/sport/{id}`

Get sport by ID.

### `GET /api/sport/name/{name}`

Get sport by name.

### `POST /api/sport`

Create sport.

### `PATCH /api/sport/{id}`

Update sport.

### `DELETE /api/sport/{id}`

Delete sport.

---

## TeamController

### `GET /api/team`

Get all teams.

### `GET /api/team/{id}`

Get team by ID.

### `GET /api/team/name/{name}`

Search teams by name.

### `GET /api/team/city/{cityName}`

Search teams by city name.

### `GET /api/team/sport/{sportId}`

Get teams by sport.

### `GET /api/team/league/{leagueId}`

Get teams by league.

### `POST /api/team`

Create team.
**Auth Required:** Yes

### `PATCH /api/team/{id}`

Update team.
**Auth Required:** Yes

### `DELETE /api/team/{id}`

Delete team.
**Auth Required:** Yes

---

## UserController

### `GET /api/user/{id}`

Get user by ID.
**Auth Required:** Yes

### `GET /api/user/username/{username}`

Get user by username.
**Auth Required:** Yes

### `GET /api/user/email/{email}`

Get user by email.
**Auth Required:** Yes

### `PATCH /api/user/{id}`

Update user.
**Auth Required:** Yes

### `DELETE /api/user/{id}`

Delete user.
**Auth Required:** Yes
