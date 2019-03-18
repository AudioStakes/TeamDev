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
PRINT N'更新が完了しました。';


GO
