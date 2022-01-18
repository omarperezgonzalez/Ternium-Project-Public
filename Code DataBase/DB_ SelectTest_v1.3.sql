-- SELECTS DE PRUEBA

SELECT * FROM dbo.Avatar;
SELECT * FROM dbo.QUIZZ;
SELECT * FROM dbo.RPG;
SELECT * FROM dbo.DECISIONES;
SELECT * FROM dbo.Game;
SELECT * FROM dbo.Question;
SELECT * FROM dbo.Answer;
SELECT * FROM dbo.Activity;
SELECT * FROM dbo.Log;
SELECT * FROM dbo.UserInfo;
SELECT * FROM dbo.[User]; 
SELECT * FROM dbo.UserTask;


-- SELECTS DE PRUEBA
/* 
-- TABLERO de RANKING
SELECT [User].Name, UserInfo.Position, Game.PlayedTime, Game.OverallScore
FROM dbo.[User]
JOIN dbo.Game ON [User].UserID = Game.UserID
JOIN dbo.UserInfo ON [User].UserInfoID = UserInfo.UserInfoID
ORDER BY OverallScore DESC, PlayedTime ASC;

-- TABLERO de Puntuacion
SELECT DISTINCT [User].Name, Game.DayScore
FROM dbo.[User]
JOIN dbo.Game ON [User].UserID = Game.UserID
ORDER BY [DayScore] DESC;

-- Tablero por juego de niveles y puntos
SELECT * FROM [User];
SELECT * FROM Game;
SELECT * FROM QUIZZ;

SELECT [User].Name, QUIZZ.Level, QUIZZ.PlayedTime, QUIZZ.Score
FROM dbo.[User]
JOIN dbo.Game ON [User].UserID = Game.UserID
JOIN dbo.QUIZZ ON Game.QUIZZID = QUIZZ.QUIZZID
ORDER BY QUIZZ.Score DESC;

SELECT [User].Name, RPG.Level, RPG.PlayedTime, RPG.Score
FROM dbo.[User]
JOIN dbo.Game ON [User].UserID = Game.UserID
JOIN dbo.RPG ON Game.RPGID = RPG.RPGID
ORDER BY RPG.Score DESC;

SELECT [User].Name, DECISIONES.Level, DECISIONES.PlayedTime, DECISIONES.Score
FROM dbo.[User]
JOIN dbo.Game ON [User].UserID = Game.UserID
JOIN dbo.DECISIONES ON Game.DECISIONESID = DECISIONES.DECISIONESID
ORDER BY DECISIONES.Score DESC;

-- Perfil User
SELECT u.Name, u.Email, i.Age, i.PhoneNum, i.JoinDate, i.UserWeb, i.UserGit, i.UserTw, i.UserIg, i.UserFb
FROM dbo.[User] as u
JOIN dbo.UserInfo as i ON u.UserInfoID = i.UserInfoID
WHERE u.Email = 'pompi@gmail.com';
 */