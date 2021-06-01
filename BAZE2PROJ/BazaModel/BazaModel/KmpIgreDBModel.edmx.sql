
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/01/2021 23:51:42
-- Generated from EDMX file: C:\Users\colak\Desktop\BazePodataka2\BAZE2PROJ\BazaModel\BazaModel\KmpIgreDBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [KmpIgreDBModel];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_KompanijaZaIgreNaSrecuPoslovnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Poslovnicas] DROP CONSTRAINT [FK_KompanijaZaIgreNaSrecuPoslovnica];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikPoslovnica]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks] DROP CONSTRAINT [FK_RadnikPoslovnica];
GO
IF OBJECT_ID(N'[dbo].[FK_KompanijaZaIgreNaSrecuOnlineSajt]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OnlineSajts] DROP CONSTRAINT [FK_KompanijaZaIgreNaSrecuOnlineSajt];
GO
IF OBJECT_ID(N'[dbo].[FK_OnlineSajtPrenosSportskogDogadjaja]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PrenosSportskogDogadjajas] DROP CONSTRAINT [FK_OnlineSajtPrenosSportskogDogadjaja];
GO
IF OBJECT_ID(N'[dbo].[FK_OnlineSajtOnlineIgraNaSrecu]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[OnlineIgraNaSrecus] DROP CONSTRAINT [FK_OnlineSajtOnlineIgraNaSrecu];
GO
IF OBJECT_ID(N'[dbo].[FK_PrenosSportskogDogadjajaGleda]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gledas] DROP CONSTRAINT [FK_PrenosSportskogDogadjajaGleda];
GO
IF OBJECT_ID(N'[dbo].[FK_GledaKlijent]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Gledas] DROP CONSTRAINT [FK_GledaKlijent];
GO
IF OBJECT_ID(N'[dbo].[FK_OnlineIgraNaSrecuIgra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igras] DROP CONSTRAINT [FK_OnlineIgraNaSrecuIgra];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentIgra]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Igras] DROP CONSTRAINT [FK_KlijentIgra];
GO
IF OBJECT_ID(N'[dbo].[FK_KlijentTiket]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Tikets] DROP CONSTRAINT [FK_KlijentTiket];
GO
IF OBJECT_ID(N'[dbo].[FK_OperaterNaUplatnomMestuStampa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stampas] DROP CONSTRAINT [FK_OperaterNaUplatnomMestuStampa];
GO
IF OBJECT_ID(N'[dbo].[FK_TiketStampa]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Stampas] DROP CONSTRAINT [FK_TiketStampa];
GO
IF OBJECT_ID(N'[dbo].[FK_OperaterNaUplatnomMestu_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_OperaterNaUplatnomMestu] DROP CONSTRAINT [FK_OperaterNaUplatnomMestu_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_RadnikObezbedjenja_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_RadnikObezbedjenja] DROP CONSTRAINT [FK_RadnikObezbedjenja_inherits_Radnik];
GO
IF OBJECT_ID(N'[dbo].[FK_OperaterUSlotSali_inherits_Radnik]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Radniks_OperaterUSlotSali] DROP CONSTRAINT [FK_OperaterUSlotSali_inherits_Radnik];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[KompanijaZaIgreNaSrecus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KompanijaZaIgreNaSrecus];
GO
IF OBJECT_ID(N'[dbo].[Poslovnicas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Poslovnicas];
GO
IF OBJECT_ID(N'[dbo].[Radniks]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks];
GO
IF OBJECT_ID(N'[dbo].[OnlineSajts]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnlineSajts];
GO
IF OBJECT_ID(N'[dbo].[PrenosSportskogDogadjajas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PrenosSportskogDogadjajas];
GO
IF OBJECT_ID(N'[dbo].[OnlineIgraNaSrecus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OnlineIgraNaSrecus];
GO
IF OBJECT_ID(N'[dbo].[Klijents]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Klijents];
GO
IF OBJECT_ID(N'[dbo].[Gledas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Gledas];
GO
IF OBJECT_ID(N'[dbo].[Igras]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Igras];
GO
IF OBJECT_ID(N'[dbo].[Tikets]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Tikets];
GO
IF OBJECT_ID(N'[dbo].[Stampas]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Stampas];
GO
IF OBJECT_ID(N'[dbo].[Radniks_OperaterNaUplatnomMestu]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_OperaterNaUplatnomMestu];
GO
IF OBJECT_ID(N'[dbo].[Radniks_RadnikObezbedjenja]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_RadnikObezbedjenja];
GO
IF OBJECT_ID(N'[dbo].[Radniks_OperaterUSlotSali]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Radniks_OperaterUSlotSali];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KompanijaZaIgreNaSrecus'
CREATE TABLE [dbo].[KompanijaZaIgreNaSrecus] (
    [IdKmp] int IDENTITY(1,1) NOT NULL,
    [NazKmp] nvarchar(max)  NOT NULL,
    [AdrKmp] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Poslovnicas'
CREATE TABLE [dbo].[Poslovnicas] (
    [IdPosl] int IDENTITY(1,1) NOT NULL,
    [Lokacija] nvarchar(max)  NOT NULL,
    [KompanijaZaIgreNaSrecuIdKmp] int  NOT NULL,
    [NazPoslovnice] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Radniks'
CREATE TABLE [dbo].[Radniks] (
    [IdRad] int IDENTITY(1,1) NOT NULL,
    [ImeRad] nvarchar(max)  NOT NULL,
    [PrezRad] nvarchar(max)  NOT NULL,
    [TipRad] nvarchar(max)  NOT NULL,
    [PoslovnicaIdPosl] int  NOT NULL,
    [PoslovnicaKompanijaZaIgreNaSrecuIdKmp] int  NOT NULL
);
GO

-- Creating table 'OnlineSajts'
CREATE TABLE [dbo].[OnlineSajts] (
    [IdSajta] int IDENTITY(1,1) NOT NULL,
    [Domen] nvarchar(max)  NOT NULL,
    [KompanijaZaIgreNaSrecuIdKmp] int  NOT NULL,
    [NazSajta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'PrenosSportskogDogadjajas'
CREATE TABLE [dbo].[PrenosSportskogDogadjajas] (
    [SifraDogadjaja] int IDENTITY(1,1) NOT NULL,
    [tipDogadjaja] nvarchar(max)  NOT NULL,
    [OnlineSajtIdSajta] int  NOT NULL,
    [OnlineSajtKompanijaZaIgreNaSrecuIdKmp] int  NOT NULL
);
GO

-- Creating table 'OnlineIgraNaSrecus'
CREATE TABLE [dbo].[OnlineIgraNaSrecus] (
    [IdIgre] int IDENTITY(1,1) NOT NULL,
    [OnlineSajtIdSajta] int  NOT NULL,
    [OnlineSajtKompanijaZaIgreNaSrecuIdKmp] int  NOT NULL,
    [NazIgre] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Klijents'
CREATE TABLE [dbo].[Klijents] (
    [IdKlijenta] int IDENTITY(1,1) NOT NULL,
    [ImeKlijenta] nvarchar(max)  NOT NULL,
    [PrezKlijenta] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Gledas'
CREATE TABLE [dbo].[Gledas] (
    [PrenosSportskogDogadjajaSifraDogadjaja] int  NOT NULL,
    [KlijentIdKlijenta] int  NOT NULL
);
GO

-- Creating table 'Igras'
CREATE TABLE [dbo].[Igras] (
    [OnlineIgraNaSrecuIdIgre] int  NOT NULL,
    [KlijentIdKlijenta] int  NOT NULL
);
GO

-- Creating table 'Tikets'
CREATE TABLE [dbo].[Tikets] (
    [SifraTiket] int IDENTITY(1,1) NOT NULL,
    [BrParova] int  NOT NULL,
    [KlijentIdKlijenta] int  NULL
);
GO

-- Creating table 'Stampas'
CREATE TABLE [dbo].[Stampas] (
    [OperaterNaUplatnomMestuIdRad] int  NOT NULL,
    [TiketSifraTiket] int  NOT NULL
);
GO

-- Creating table 'Radniks_OperaterNaUplatnomMestu'
CREATE TABLE [dbo].[Radniks_OperaterNaUplatnomMestu] (
    [IdRad] int  NOT NULL
);
GO

-- Creating table 'Radniks_RadnikObezbedjenja'
CREATE TABLE [dbo].[Radniks_RadnikObezbedjenja] (
    [Vestine] nvarchar(max)  NOT NULL,
    [IdRad] int  NOT NULL
);
GO

-- Creating table 'Radniks_OperaterUSlotSali'
CREATE TABLE [dbo].[Radniks_OperaterUSlotSali] (
    [Plata] nvarchar(max)  NOT NULL,
    [IdRad] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdKmp] in table 'KompanijaZaIgreNaSrecus'
ALTER TABLE [dbo].[KompanijaZaIgreNaSrecus]
ADD CONSTRAINT [PK_KompanijaZaIgreNaSrecus]
    PRIMARY KEY CLUSTERED ([IdKmp] ASC);
GO

-- Creating primary key on [IdPosl], [KompanijaZaIgreNaSrecuIdKmp] in table 'Poslovnicas'
ALTER TABLE [dbo].[Poslovnicas]
ADD CONSTRAINT [PK_Poslovnicas]
    PRIMARY KEY CLUSTERED ([IdPosl], [KompanijaZaIgreNaSrecuIdKmp] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [PK_Radniks]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- Creating primary key on [IdSajta], [KompanijaZaIgreNaSrecuIdKmp] in table 'OnlineSajts'
ALTER TABLE [dbo].[OnlineSajts]
ADD CONSTRAINT [PK_OnlineSajts]
    PRIMARY KEY CLUSTERED ([IdSajta], [KompanijaZaIgreNaSrecuIdKmp] ASC);
GO

-- Creating primary key on [SifraDogadjaja] in table 'PrenosSportskogDogadjajas'
ALTER TABLE [dbo].[PrenosSportskogDogadjajas]
ADD CONSTRAINT [PK_PrenosSportskogDogadjajas]
    PRIMARY KEY CLUSTERED ([SifraDogadjaja] ASC);
GO

-- Creating primary key on [IdIgre] in table 'OnlineIgraNaSrecus'
ALTER TABLE [dbo].[OnlineIgraNaSrecus]
ADD CONSTRAINT [PK_OnlineIgraNaSrecus]
    PRIMARY KEY CLUSTERED ([IdIgre] ASC);
GO

-- Creating primary key on [IdKlijenta] in table 'Klijents'
ALTER TABLE [dbo].[Klijents]
ADD CONSTRAINT [PK_Klijents]
    PRIMARY KEY CLUSTERED ([IdKlijenta] ASC);
GO

-- Creating primary key on [PrenosSportskogDogadjajaSifraDogadjaja], [KlijentIdKlijenta] in table 'Gledas'
ALTER TABLE [dbo].[Gledas]
ADD CONSTRAINT [PK_Gledas]
    PRIMARY KEY CLUSTERED ([PrenosSportskogDogadjajaSifraDogadjaja], [KlijentIdKlijenta] ASC);
GO

-- Creating primary key on [KlijentIdKlijenta], [OnlineIgraNaSrecuIdIgre] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [PK_Igras]
    PRIMARY KEY CLUSTERED ([KlijentIdKlijenta], [OnlineIgraNaSrecuIdIgre] ASC);
GO

-- Creating primary key on [SifraTiket] in table 'Tikets'
ALTER TABLE [dbo].[Tikets]
ADD CONSTRAINT [PK_Tikets]
    PRIMARY KEY CLUSTERED ([SifraTiket] ASC);
GO

-- Creating primary key on [OperaterNaUplatnomMestuIdRad], [TiketSifraTiket] in table 'Stampas'
ALTER TABLE [dbo].[Stampas]
ADD CONSTRAINT [PK_Stampas]
    PRIMARY KEY CLUSTERED ([OperaterNaUplatnomMestuIdRad], [TiketSifraTiket] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks_OperaterNaUplatnomMestu'
ALTER TABLE [dbo].[Radniks_OperaterNaUplatnomMestu]
ADD CONSTRAINT [PK_Radniks_OperaterNaUplatnomMestu]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks_RadnikObezbedjenja'
ALTER TABLE [dbo].[Radniks_RadnikObezbedjenja]
ADD CONSTRAINT [PK_Radniks_RadnikObezbedjenja]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- Creating primary key on [IdRad] in table 'Radniks_OperaterUSlotSali'
ALTER TABLE [dbo].[Radniks_OperaterUSlotSali]
ADD CONSTRAINT [PK_Radniks_OperaterUSlotSali]
    PRIMARY KEY CLUSTERED ([IdRad] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KompanijaZaIgreNaSrecuIdKmp] in table 'Poslovnicas'
ALTER TABLE [dbo].[Poslovnicas]
ADD CONSTRAINT [FK_KompanijaZaIgreNaSrecuPoslovnica]
    FOREIGN KEY ([KompanijaZaIgreNaSrecuIdKmp])
    REFERENCES [dbo].[KompanijaZaIgreNaSrecus]
        ([IdKmp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KompanijaZaIgreNaSrecuPoslovnica'
CREATE INDEX [IX_FK_KompanijaZaIgreNaSrecuPoslovnica]
ON [dbo].[Poslovnicas]
    ([KompanijaZaIgreNaSrecuIdKmp]);
GO

-- Creating foreign key on [PoslovnicaIdPosl], [PoslovnicaKompanijaZaIgreNaSrecuIdKmp] in table 'Radniks'
ALTER TABLE [dbo].[Radniks]
ADD CONSTRAINT [FK_RadnikPoslovnica]
    FOREIGN KEY ([PoslovnicaIdPosl], [PoslovnicaKompanijaZaIgreNaSrecuIdKmp])
    REFERENCES [dbo].[Poslovnicas]
        ([IdPosl], [KompanijaZaIgreNaSrecuIdKmp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RadnikPoslovnica'
CREATE INDEX [IX_FK_RadnikPoslovnica]
ON [dbo].[Radniks]
    ([PoslovnicaIdPosl], [PoslovnicaKompanijaZaIgreNaSrecuIdKmp]);
GO

-- Creating foreign key on [KompanijaZaIgreNaSrecuIdKmp] in table 'OnlineSajts'
ALTER TABLE [dbo].[OnlineSajts]
ADD CONSTRAINT [FK_KompanijaZaIgreNaSrecuOnlineSajt]
    FOREIGN KEY ([KompanijaZaIgreNaSrecuIdKmp])
    REFERENCES [dbo].[KompanijaZaIgreNaSrecus]
        ([IdKmp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KompanijaZaIgreNaSrecuOnlineSajt'
CREATE INDEX [IX_FK_KompanijaZaIgreNaSrecuOnlineSajt]
ON [dbo].[OnlineSajts]
    ([KompanijaZaIgreNaSrecuIdKmp]);
GO

-- Creating foreign key on [OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp] in table 'PrenosSportskogDogadjajas'
ALTER TABLE [dbo].[PrenosSportskogDogadjajas]
ADD CONSTRAINT [FK_OnlineSajtPrenosSportskogDogadjaja]
    FOREIGN KEY ([OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp])
    REFERENCES [dbo].[OnlineSajts]
        ([IdSajta], [KompanijaZaIgreNaSrecuIdKmp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OnlineSajtPrenosSportskogDogadjaja'
CREATE INDEX [IX_FK_OnlineSajtPrenosSportskogDogadjaja]
ON [dbo].[PrenosSportskogDogadjajas]
    ([OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp]);
GO

-- Creating foreign key on [OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp] in table 'OnlineIgraNaSrecus'
ALTER TABLE [dbo].[OnlineIgraNaSrecus]
ADD CONSTRAINT [FK_OnlineSajtOnlineIgraNaSrecu]
    FOREIGN KEY ([OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp])
    REFERENCES [dbo].[OnlineSajts]
        ([IdSajta], [KompanijaZaIgreNaSrecuIdKmp])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OnlineSajtOnlineIgraNaSrecu'
CREATE INDEX [IX_FK_OnlineSajtOnlineIgraNaSrecu]
ON [dbo].[OnlineIgraNaSrecus]
    ([OnlineSajtIdSajta], [OnlineSajtKompanijaZaIgreNaSrecuIdKmp]);
GO

-- Creating foreign key on [PrenosSportskogDogadjajaSifraDogadjaja] in table 'Gledas'
ALTER TABLE [dbo].[Gledas]
ADD CONSTRAINT [FK_PrenosSportskogDogadjajaGleda]
    FOREIGN KEY ([PrenosSportskogDogadjajaSifraDogadjaja])
    REFERENCES [dbo].[PrenosSportskogDogadjajas]
        ([SifraDogadjaja])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KlijentIdKlijenta] in table 'Gledas'
ALTER TABLE [dbo].[Gledas]
ADD CONSTRAINT [FK_GledaKlijent]
    FOREIGN KEY ([KlijentIdKlijenta])
    REFERENCES [dbo].[Klijents]
        ([IdKlijenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_GledaKlijent'
CREATE INDEX [IX_FK_GledaKlijent]
ON [dbo].[Gledas]
    ([KlijentIdKlijenta]);
GO

-- Creating foreign key on [OnlineIgraNaSrecuIdIgre] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [FK_OnlineIgraNaSrecuIgra]
    FOREIGN KEY ([OnlineIgraNaSrecuIdIgre])
    REFERENCES [dbo].[OnlineIgraNaSrecus]
        ([IdIgre])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OnlineIgraNaSrecuIgra'
CREATE INDEX [IX_FK_OnlineIgraNaSrecuIgra]
ON [dbo].[Igras]
    ([OnlineIgraNaSrecuIdIgre]);
GO

-- Creating foreign key on [KlijentIdKlijenta] in table 'Igras'
ALTER TABLE [dbo].[Igras]
ADD CONSTRAINT [FK_KlijentIgra]
    FOREIGN KEY ([KlijentIdKlijenta])
    REFERENCES [dbo].[Klijents]
        ([IdKlijenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [KlijentIdKlijenta] in table 'Tikets'
ALTER TABLE [dbo].[Tikets]
ADD CONSTRAINT [FK_KlijentTiket]
    FOREIGN KEY ([KlijentIdKlijenta])
    REFERENCES [dbo].[Klijents]
        ([IdKlijenta])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_KlijentTiket'
CREATE INDEX [IX_FK_KlijentTiket]
ON [dbo].[Tikets]
    ([KlijentIdKlijenta]);
GO

-- Creating foreign key on [OperaterNaUplatnomMestuIdRad] in table 'Stampas'
ALTER TABLE [dbo].[Stampas]
ADD CONSTRAINT [FK_OperaterNaUplatnomMestuStampa]
    FOREIGN KEY ([OperaterNaUplatnomMestuIdRad])
    REFERENCES [dbo].[Radniks_OperaterNaUplatnomMestu]
        ([IdRad])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [TiketSifraTiket] in table 'Stampas'
ALTER TABLE [dbo].[Stampas]
ADD CONSTRAINT [FK_TiketStampa]
    FOREIGN KEY ([TiketSifraTiket])
    REFERENCES [dbo].[Tikets]
        ([SifraTiket])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_TiketStampa'
CREATE INDEX [IX_FK_TiketStampa]
ON [dbo].[Stampas]
    ([TiketSifraTiket]);
GO

-- Creating foreign key on [IdRad] in table 'Radniks_OperaterNaUplatnomMestu'
ALTER TABLE [dbo].[Radniks_OperaterNaUplatnomMestu]
ADD CONSTRAINT [FK_OperaterNaUplatnomMestu_inherits_Radnik]
    FOREIGN KEY ([IdRad])
    REFERENCES [dbo].[Radniks]
        ([IdRad])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdRad] in table 'Radniks_RadnikObezbedjenja'
ALTER TABLE [dbo].[Radniks_RadnikObezbedjenja]
ADD CONSTRAINT [FK_RadnikObezbedjenja_inherits_Radnik]
    FOREIGN KEY ([IdRad])
    REFERENCES [dbo].[Radniks]
        ([IdRad])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- Creating foreign key on [IdRad] in table 'Radniks_OperaterUSlotSali'
ALTER TABLE [dbo].[Radniks_OperaterUSlotSali]
ADD CONSTRAINT [FK_OperaterUSlotSali_inherits_Radnik]
    FOREIGN KEY ([IdRad])
    REFERENCES [dbo].[Radniks]
        ([IdRad])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------