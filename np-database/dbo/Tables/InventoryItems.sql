CREATE TABLE [dbo].[InventoryItems]
(
	[InventoryItemId] INT IDENTITY (1, 1) NOT NULL,
    [CharacterName] NVARCHAR(MAX) NULL, 
    [Location] NVARCHAR(MAX) NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    [ItemId] INT NOT NULL, 
    [Count] INT NOT NULL, 
    [Slots] INT NOT NULL, 
    [Active] BIT NOT NULL DEFAULT 0, 
    [Public] BIT NOT NULL DEFAULT 1, 
    [Imported] BIT NOT NULL DEFAULT 0, 
    CONSTRAINT [PK_InventoryItem] PRIMARY KEY CLUSTERED ([InventoryItemId] ASC), 
)
