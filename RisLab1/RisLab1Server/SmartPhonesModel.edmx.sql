
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/25/2016 10:53:49
-- Generated from EDMX file: C:\Users\antonpoluianov\Source\Repos\RisLab1\RisLab1\RisLab1Server\SmartPhonesModel.edmx
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

-- Creating table 'SpecificationSet'
CREATE TABLE [dbo].[SpecificationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [RAMInGB] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SmartPhoneSet'
CREATE TABLE [dbo].[SmartPhoneSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Model] nvarchar(max)  NOT NULL,
    [SpecificationsId] int  NOT NULL,
    [SpecificationId] int  NOT NULL,
    [BrandId] int  NOT NULL
);
GO

-- Creating table 'BrandSet'
CREATE TABLE [dbo].[BrandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LocationsByBrandSet'
CREATE TABLE [dbo].[LocationsByBrandSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [BrandId] int  NOT NULL,
    [LocationId] int  NOT NULL
);
GO

-- Creating table 'LocationSet'
CREATE TABLE [dbo].[LocationSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Address] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'SpecificationSet'
ALTER TABLE [dbo].[SpecificationSet]
ADD CONSTRAINT [PK_SpecificationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SmartPhoneSet'
ALTER TABLE [dbo].[SmartPhoneSet]
ADD CONSTRAINT [PK_SmartPhoneSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'BrandSet'
ALTER TABLE [dbo].[BrandSet]
ADD CONSTRAINT [PK_BrandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [PK_LocationsByBrandSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LocationSet'
ALTER TABLE [dbo].[LocationSet]
ADD CONSTRAINT [PK_LocationSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [SpecificationId] in table 'SmartPhoneSet'
ALTER TABLE [dbo].[SmartPhoneSet]
ADD CONSTRAINT [FK_SpecificationSmartPhone]
    FOREIGN KEY ([SpecificationId])
    REFERENCES [dbo].[SpecificationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_SpecificationSmartPhone'
CREATE INDEX [IX_FK_SpecificationSmartPhone]
ON [dbo].[SmartPhoneSet]
    ([SpecificationId]);
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

-- Creating foreign key on [BrandId] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [FK_BrandLocationsByBrand]
    FOREIGN KEY ([BrandId])
    REFERENCES [dbo].[BrandSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_BrandLocationsByBrand'
CREATE INDEX [IX_FK_BrandLocationsByBrand]
ON [dbo].[LocationsByBrandSet]
    ([BrandId]);
GO

-- Creating foreign key on [LocationId] in table 'LocationsByBrandSet'
ALTER TABLE [dbo].[LocationsByBrandSet]
ADD CONSTRAINT [FK_LocationLocationsByBrand]
    FOREIGN KEY ([LocationId])
    REFERENCES [dbo].[LocationSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LocationLocationsByBrand'
CREATE INDEX [IX_FK_LocationLocationsByBrand]
ON [dbo].[LocationsByBrandSet]
    ([LocationId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------