SET IDENTITY_INSERT [dbo].[Bus] ON
INSERT INTO [dbo].[Bus] ([Id], [BusNumber], [TransportCompany]) VALUES (1, N'ABC12', N'Auckland Buses')
INSERT INTO [dbo].[Bus] ([Id], [BusNumber], [TransportCompany]) VALUES (2, N'A1B21', N'LUXURY Travel')
INSERT INTO [dbo].[Bus] ([Id], [BusNumber], [TransportCompany]) VALUES (3, N'FCGF6', N'City Travels')
INSERT INTO [dbo].[Bus] ([Id], [BusNumber], [TransportCompany]) VALUES (4, N'HYU433', N'Central Travels')
SET IDENTITY_INSERT [dbo].[Bus] OFF
SET IDENTITY_INSERT [dbo].[Driver] ON
INSERT INTO [dbo].[Driver] ([Id], [Name], [PhoneNumber]) VALUES (1, N'Harry Gray', N'02166678901')
INSERT INTO [dbo].[Driver] ([Id], [Name], [PhoneNumber]) VALUES (2, N'Nick James', N'02199956789')
INSERT INTO [dbo].[Driver] ([Id], [Name], [PhoneNumber]) VALUES (3, N'Bill Devonport', N'0219991234')
SET IDENTITY_INSERT [dbo].[Driver] OFF
SET IDENTITY_INSERT [dbo].[Route] ON
INSERT INTO [dbo].[Route] ([Id], [Name], [RouteDistance]) VALUES (1, N'Papakura/Britomart', 40)
INSERT INTO [dbo].[Route] ([Id], [Name], [RouteDistance]) VALUES (2, N'Biritomart/North Shore', 25)
INSERT INTO [dbo].[Route] ([Id], [Name], [RouteDistance]) VALUES (3, N'Britomart/ Mount Eden', 10)
SET IDENTITY_INSERT [dbo].[Route] OFF
SET IDENTITY_INSERT [dbo].[RouteAllocation] ON
INSERT INTO [dbo].[RouteAllocation] ([Id], [BusId], [DriverId], [RouteId]) VALUES (1, 1, 1, 2)
INSERT INTO [dbo].[RouteAllocation] ([Id], [BusId], [DriverId], [RouteId]) VALUES (2, 2, 2, 3)
INSERT INTO [dbo].[RouteAllocation] ([Id], [BusId], [DriverId], [RouteId]) VALUES (3, 4, 3, 1)
SET IDENTITY_INSERT [dbo].[RouteAllocation] OFF
