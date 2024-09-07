# Skinet 2024
> - .Net 8 (ASP.NET Core Web API)
> - Angular 18

## Commands
```
npm --version
npm uninstall -g @angular/cli
npm cache clean --force
Delete the C:\Users\YOU\AppData\Roaming\npm\node_modules\@angular

npm install -g @angular/cli
- npm install -g @angular/cli@17
- npm install -g @angular/cli@14

ng new <project-name>


dotnet new sln -n skinet
dotnet new webapi -o API -controllers
dotnet new classlib -o Core
dotnet new classlib -o Infrastructure

dotnet sln add API
dotnet sln add Core
dotnet sln add Infrastructure

dotnet sln list

API → dotnet add reference ../Infrastructure
Infrastructure → dotnet add reference ../Core

dotnet restore
dotnet build
dotnet dev-certs https
dotnet dev-certs https --trust

git config --global user.email "you@example.com"
git config --global user.name "Your Name"

dotnet new gitignore
```
