-- INSERTS DE PRUEBA

INSERT INTO dbo.Avatar 
(SkinColor, Eyes, Eyebrows, Mouth, HairStyle, HairColor, FacialHair, Clothes, FabricColor, Glasses, GlassesOpac, Accesories, Tattoos, BackgroundColor) VALUES 
(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14), 
(2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1), 
(3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2),
(4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2, 3),
(5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 1, 2, 3, 4);

INSERT INTO dbo.QUIZZ
(Name, Score) VALUES
('QUIZZ', 123),
('QUIZZ', 234),
('QUIZZ', 345);

INSERT INTO dbo.RPG 
(Name, PlayedTime, Level, Quests, TimeByQ, Score) VALUES
('RPG', '10:10:10', 1, 2, '05:05:05', 123),
('RPG', '09:09:09', 2, 3, '03:03:03', 234),
('RPG', '01:00:00', 3, 4, '00:15:00', 345);

INSERT INTO dbo.DECISIONES 
(Name, PlayedTime, Level, Decisions, Score) VALUES
('DECISIONES', 0.01, 1, 11, 123),
('DECISIONES', 1.10, 2, 5, 234);

INSERT INTO dbo.Question
(Question, Status, Theme, Difficulty) VALUES
('¿Qué pesa más: Un kilo de plumas o uno de metal?', 1, 'Cultura', 2),
('2 + 2 = ', 0, 'Matematicas', 1),
('Selecciona la respuesta correcta', 1, 'Prueba', 1),
('¿Jorge Barbilla?', 1, 'Secreta', 3);

INSERT INTO dbo.Answer
(QuestionID, CorrectAnswer, AnswerContent) VALUES
(1, 1, 'Igual'),
(1, 1, 'Plumas'),
(1, 1, 'Metal'),
(1, 1, 'No sé'),
(2, 5, '4'),
(2, 5, '5'),
(2, 5, '3'),
(2, 5, 'Todas'),
(3, 9, 'Correcta'),
(3, 9, 'Errónea'),
(3, 9, 'Trampa'),
(3, 9, 'Esta no'),
(4, 13, 'Es verdad'),
(4, 13, 'Cierto'),
(4, 13, 'Así es'),
(4, 13, 'No');

INSERT INTO dbo.Activity
(ActivityContent, Theme) VALUES
('Login', 'Login'),
('Actualizacion de info', 'Info');

INSERT INTO dbo.UserInfo
(UserBio, Position, Age, PhoneNum, JoinDate, UserWeb, UserGit, UserTw, UserIg, UserFb, LastConnection) VALUES
('Me llamo pompilio pero me dicen pompi', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'pompi.com', '@pompi', '@pompi', '@pompi', '@pompi', '2021-03-07 07:00:00'),
('Me llamo agripino pero me dicen agri', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'agri.com', '@agri', '@agri', '@agri', '@agri', '2021-03-07 07:00:00'),
('Me llamo celestina pero me dicen tina', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'tina.com', '@tina', '@tina', '@tina', '@tina', '2021-03-07 07:00:00'),
('Me llamo hermenegildo pero me dicen hermes', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'hermes.com', '@hermes', '@hermes', '@hermes', '@hermes', '2021-03-07 07:00:00'),
('Me llamo macario y me gusta el guajolote', 'Ventas', 20, '+52 123 456 7890', '2021-03-07 07:00:00', 'guajolotelover.com', '@guajolotelover', '@guajolotelover', '@guajolotelover', '@guajolotelover', '2021-03-07 07:00:00');

INSERT INTO dbo.[User]
(AvatarID, UserInfoID, Name, Email, Password, Status, TypeUser) VALUES 
(1, 1, 'Pompilio', 'pompi@gmail.com', 'contrasenia123', 1, 1), 
(2, 2, 'Agripino', 'agri@gmail.com', 'pizzaytaquitos0', 1, 2), 
(3, 3, 'Celestina', 'tina@gmail.com', 'GrrMalditoConejo', 0, 3), 
(4, 4, 'Hermenegildo', 'hermes@gmail.com', 'nosequeponer1', 0, 1), 
(5, 5, 'Macario', 'macario@gmail.com', 'elguajoloteesmio3', 0, 1);

INSERT INTO dbo.Game
(UserID, QUIZZID, RPGID, DECISIONESID, Name, PlayedTime, DayScore, WeekScore, Monthscore, OverallScore) VALUES 
(1, 1, NULL, NULL, 'QUIZZ', 0.1, 9, 99, 999, 9999),
(2, NULL, 1, NULL, 'RPG', 1.0, 10, 20, 30, 40),
(3, NULL, NULL, 1, 'DECISIONES', 0.1, 11, 11, 11, 11),
(4, 2, NULL, NULL, 'QUIZZ', 1.0, 8, 100, 998, 10000),
(5, NULL, 2, NULL, 'RPG', 0.1, 9, 18, 27, 45),
(1, NULL, NULL, 2, 'DECISIONES', 1.0, 10, 20, 30, 40),
(2, 3, NULL, NULL, 'QUIZZ', 0.1, 11, 11, 11, 11),
(3, NULL, 3, NULL, 'RPG', 1.0, 9, 18, 27, 45);

INSERT INTO dbo.UserTask
(UserID, Description, TaskDate, TaskStatus) VALUES
(1, 'Actualizar base de datos', '2021-03-07 06:59:41', 0),
(1, 'Actualizar juegos', '2021-03-07 06:59:41', 1),
(2, 'Actualizar pagina web', '2021-03-07 06:59:41', 0),
(3, 'Actualizar otra cosa', '2021-03-07 06:59:41', 1),
(4, 'Actualizar algo', '2021-03-07 06:59:41', 0),
(5, 'Actualizar idk', '2021-03-07 06:59:41', 0);

INSERT INTO dbo.Log
(UserID, ActivityID, AnswerID, LogDate, LogType) VALUES
(1, NULL, 1, '2021-03-07 06:59:41', 1),
(2, NULL, 6, '2021-03-07 06:59:42', 1),
(3, NULL, 11, '2021-03-07 06:59:43', 1),
(4, NULL, 13, '2021-03-07 06:59:44', 1),
(5, NULL, 2, '2021-03-07 06:59:41', 1),
(1, NULL, 5, '2021-03-07 06:59:42', 1),
(2, NULL, 10, '2021-03-07 06:59:43', 1),
(3, NULL, 15, '2021-03-07 06:59:44', 1),
(4, 1, NULL, '2021-03-07 06:59:44', 0),
(5, 2, NULL, '2021-03-07 06:59:44', 0);
