build:
	dotnet build ./code/csharp/Nebu

test:
	dotnet test ./code/csharp/Nebu

api:
	dotnet run --project ./code/csharp/Nebu/Nebu.Api/Nebu.Api.csproj


## compose

# composes dependencies
compose-deps:
	docker compose up --build -d db

# composes api and its dependencies
compose-api:
	docker compose up --build -d api

compose-down:
	docker compose down


## ci

ci-restore:
	dotnet restore ./code/csharp/Nebu

ci-build:
	dotnet build ./code/csharp/Nebu --no-restore

ci-test:
	dotnet text ./code/csharp/Nebu --no-build --verbosity normal
