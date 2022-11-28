title receiver
dapr run --app-id receiver --app-port 5238 --components-path ./components -- dotnet run --project ./receiver/receiver.csproj
