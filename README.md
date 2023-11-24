# nebu

`nebu`, after Morphesus's ship Nebuchadnezzar. A monorepo byoc personal file syncing solution.

## Running nebu

After provisioning dependencies, you should be able to do most work via the `Makefile`.

Basic code commands:

- `make build`
- `make test`

There are two ways to run the API: in a composed cluster, or on its own against a cluster of dependencies.

- `make compose-api` runs the API and all dependencies in Docker
- `make compose-deps` runs just the dependencies of the API
  - `make api` runs the API using `dotnet run` for less build time and ease of debuggability

Call `make compose-down` to cleanup containers and get a fresh local environment.

Visit [http://localhost:8080/swagger/index.html](http://localhost:8080/swagger/index.html) to view the swagger UI in either run configuration.

## Dependencies

Dependencies are intended to stay as minimal as possible. You'll need:

- [Docker Desktop](https://www.docker.com/products/docker-desktop/) (a relatively recent version that includes `compose`)
- [dotnet core sdk 8](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [VS Code](https://code.visualstudio.com/download) is recommended as an editor, workspace config and extension recommendations are included
