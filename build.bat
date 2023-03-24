cd Movii
dotnet publish Movii.Api/movii.api.csproj -o ../publish
cd..
docker build -t moviiapi_v2 -f Dockerfile-Runtime .
cd Movii
docker-compose up
