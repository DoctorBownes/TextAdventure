project=Zuul
framework=netcoreapp3.1
config=Debug
# config=Release

all: run
	
build:
	dotnet build ${project}.sln --configuration "${config}"

run: build
	clear
	@dotnet exec ${project}/bin/${config}/${framework}/${project}.dll

clean:
	dotnet clean ${project}.sln --configuration "${config}"
