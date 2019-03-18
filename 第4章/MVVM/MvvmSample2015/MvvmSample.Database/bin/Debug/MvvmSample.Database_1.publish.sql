/*
MvvmSample.Database の配置スクリプト

このコードはツールによって生成されました。
このファイルへの変更は、正しくない動作の原因になる可能性があると共に、
コードが再生成された場合に失われます。
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "MvvmSample.Database"
:setvar DefaultFilePrefix "MvvmSample.Database"
:setvar DefaultDataPath "C:\Users\harp179\AppData\Local\Microsoft\VisualStudio\SSDT"
:setvar DefaultLogPath "C:\Users\harp179\AppData\Local\Microsoft\VisualStudio\SSDT"

GO
:on error exit
GO
/*
SQLCMD モードを検出して、SQLCMD モードがサポートされていない場合にスクリプトの実行を無効にします。
SQLCMD モードを有効化した後でスクリプトを再度有効にするには、次を実行します:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'このスクリプトを正常に実行するには SQLCMD モードを有効にする必要があります。';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET ARITHABORT ON,
                CONCAT_NULL_YIELDS_NULL ON,
                CURSOR_DEFAULT LOCAL 
            WITH ROLLBACK IMMEDIATE;
    END


GO
IF EXISTS (SELECT 1
           FROM   [master].[dbo].[sysdatabases]
           WHERE  [name] = N'$(DatabaseName)')
    BEGIN
        ALTER DATABASE [$(DatabaseName)]
            SET PAGE_VERIFY NONE,
                DISABLE_BROKER 
            WITH ROLLBACK IMMEDIATE;
    END


GO
ALTER DATABASE [$(DatabaseName)]
    SET TARGET_RECOVERY_TIME = 0 SECONDS 
    WITH ROLLBACK IMMEDIATE;


GO
PRINT N'[dbo].[Products] を作成しています...';


GO
CREATE TABLE [dbo].[Products] (
    [Id]           INT             IDENTITY (1, 1) NOT NULL,
    [Title]        NVARCHAR (200)  NOT NULL,
    [ProductUrl]   NVARCHAR (2100) NULL,
    [DownloadUrl]  NVARCHAR (2100) NULL,
    [Description]  NVARCHAR (MAX)  NULL,
    [Publisher]    NVARCHAR (200)  NULL,
    [PublisherUrl] NVARCHAR (2100) NULL,
    [ImageUrl]     NVARCHAR (2100) NULL,
    [Price]        MONEY           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'[dbo].[Products].[ProductsIndex2] を作成しています...';


GO
CREATE NONCLUSTERED INDEX [ProductsIndex2]
    ON [dbo].[Products]([Publisher] ASC);


GO
PRINT N'[dbo].[Products].[ProductsIndex1] を作成しています...';


GO
CREATE NONCLUSTERED INDEX [ProductsIndex1]
    ON [dbo].[Products]([Title] ASC);


GO
PRINT N'更新が完了しました。';


GO
