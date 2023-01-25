USE [CodeMaze]
GO
INSERT [dbo].[Owners] ([Id], [Name], [Address]) VALUES (N'c0dd7cc1-c6e8-47e0-857a-19821de0de79', N'Sharad Pise', N'Pune, India')
GO
INSERT [dbo].[Owners] ([Id], [Name], [Address]) VALUES (N'eeb192d9-df1c-4399-82fd-74d4662034f1', N'John Doe', N'Luisiana, US')
GO
INSERT [dbo].[Owners] ([Id], [Name], [Address]) VALUES (N'13048e87-1bb5-4c7a-84ed-b8e1385b6d1e', N'Jignesh Patel', N'Diu, India')
GO
INSERT [dbo].[Owners] ([Id], [Name], [Address]) VALUES (N'bb4fd0ed-eef6-4cd9-8e2c-e442501eed17', N'Jane Doe', N'Texas, US')
GO
INSERT [dbo].[Accounts] ([Id], [Type], [Description], [OwnerId]) VALUES (N'fc56c65f-c207-4eca-ab71-523037db716f', 1, N'Savings account for our users', N'bb4fd0ed-eef6-4cd9-8e2c-e442501eed17')
GO
INSERT [dbo].[Accounts] ([Id], [Type], [Description], [OwnerId]) VALUES (N'78e0f8ab-b116-48ef-8e6d-78a567fe18c2', 3, N'Income account for our users', N'bb4fd0ed-eef6-4cd9-8e2c-e442501eed17')
GO
INSERT [dbo].[Accounts] ([Id], [Type], [Description], [OwnerId]) VALUES (N'a0d8732e-ff7c-407a-b6c1-e0339dbf62bd', 0, N'Cash account for our users', N'eeb192d9-df1c-4399-82fd-74d4662034f1')
GO
