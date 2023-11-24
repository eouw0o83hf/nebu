build:
	dotnet build ./code/csharp/Nebu

test:
	dotnet test ./code/csharp/Nebu

api:
	dotnet run --project ./code/csharp/Nebu/Nebu.Api/Nebu.Api.csproj

# composes dependencies
compose-deps:
	docker compose up --build -d db

# composes api and its dependencies
compose-api:
	docker compose up --build -d api

compose-down:
	docker compose down
