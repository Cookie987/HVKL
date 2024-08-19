@echo off
chcp 65001


dotnet publish -p:PublishProfile=FolderProfile 
pause