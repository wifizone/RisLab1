
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/12/2016 18:27:23
-- Generated from EDMX file: C:\Users\anton\Source\Repos\RisLab1\RisLab1\RisLab1\SmartPhoneDb.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SmartPhones];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'SmartPhoneSet'
CREATE TABLE [dbo].[SmartPhoneSet] (
    [Id] int  NOT NULL,
    [BrandId] int  NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [SpecificationsId] int  NOT NULL
);
GO

-- Creating table 'SpecificationSet'
CREATE TABLE [dbo].[SpecificationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RAMInGB] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'BrandSet'
CREATE TABLE [dbo].[BrandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [PlantLocationsId] int  NOT NULL
);
GO

-- Creating table 'LocationsSet'
CREATE TABLE [dbo].[LocationsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LocationsByBrandSet'
CREATE TABLE [dbo].[LocationsByBrandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlantLocationsId] int  NOT NULL,
    [LocationsId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SmartPhoneSet'
ALTER TABLE [dbo].[SmartPhoneSet]
ADD CONSTRAINT [PK_SmartPhoneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SpecificationSet'
ALTER TABLE [dbo].[SpecificationSet]
ADD CONSTRAINT [PK_SpecificationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BrandSet'
ALTER TABLE [dbo].[BrandSet]
ADD CONSTRAINT [PK_BrandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationsSet'
ALTER TABLE [dbo].[LocationsSet]
ADD CONSTRAINT [PK_LocationsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [PK_LocationsByBrandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SpecificationsId] in table 'SmartPhoneSet'
ALTER TABLE [dbo].[SmartPhoneSet]
ADD CONSTRAINT [FK_SmartPhoneSpecification]
    FOREIGN KEY ([SpecificationsId])
    REFERENCES [dbo].[SpecificationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SmartPhoneSpecification'
CREATE INDEX [IX_FK_SmartPhoneSpecification]
ON [dbo].[SmartPhoneSet]
    ([SpecificationsId]);
GO

-- Creating foreign key on [BrandId] in table 'SmartPhoneSet'
ALTER TABLE [dbo].[SmartPhoneSet]
ADD CONSTRAINT [FK_BrandSmartPhone]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[BrandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrandSmartPhone'
CREATE INDEX [IX_FK_BrandSmartPhone]
ON [dbo].[SmartPhoneSet]
    ([BrandId]);
GO

-- Creating foreign key on [LocationsId] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [FK_LocationsLocationsByBrand]
    FOREIGN KEY ([LocationsId])
    REFERENCES [dbo].[LocationsSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationsLocationsByBrand'
CREATE INDEX [IX_FK_LocationsLocationsByBrand]
ON [dbo].[LocationsByBrandSet]
    ([LocationsId]);
GO

-- Creating foreign key on [PlantLocationsId] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [FK_BrandLocationsByBrand]
    FOREIGN KEY ([PlantLocationsId])
    REFERENCES [dbo].[BrandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrandLocationsByBrand'
CREATE INDEX [IX_FK_BrandLocationsByBrand]
ON [dbo].[LocationsByBrandSet]
    ([PlantLocationsId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------