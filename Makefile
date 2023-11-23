build:
	dotnet build ./code/csharp/Nebu

test:
	dotnet test ./code/csharp/Nebu

compose-up:
	docker compose up

compose-down:
	docker compose down
