FROM 823934831816.dkr.ecr.eu-west-1.amazonaws.com/sdk:7.0-bullseye-slim-1.0.0 AS build-env
WORKDIR /app

# Get Azure DevOps PAT from args
ARG AZDO_PAT

# Setup cred-provider
ENV VSS_NUGET_EXTERNAL_FEED_ENDPOINTS {\"endpointCredentials\": [{\"endpoint\":\"https://pkgs.dev.azure.com/cponsn/_packaging/my-very-private-feed/nuget/v3/index.json\", \"username\":\"build\", \"password\":\"$AZDO_PAT\"}]}

# Copy everything and restore packages
COPY . ./
RUN dotnet restore -s "https://pkgs.dev.azure.com/cponsn/_packaging/my-very-private-feed/nuget/v3/index.json" \
    -s "https://api.nuget.org/v3/index.json" \
	--runtime linux-x64	

# Build project
RUN dotnet build "./src/BookStore.WebApi/BookStore.WebApi.csproj" \ 
    -c Release \
	--runtime linux-x64 \ 
	--self-contained true \	
	--no-restore


# Publish app
RUN dotnet publish "./src/BookStore.WebApi/BookStore.WebApi.csproj" \
	-c Release \
	-o /app/publish \
	--no-restore \ 
	--no-build \
	--self-contained true \
	--runtime linux-x64 \
	/p:PublishTrimmed=true

# Build runtime image
FROM 823934831816.dkr.ecr.eu-west-1.amazonaws.com/runtime-deps:7.0-bullseye-slim-1.0.0

# Expose port
EXPOSE 8080

# Copy artifact
WORKDIR /app
COPY --from=build-env /app/publish .

# Set entrypoint
ENTRYPOINT ["./BookStore.WebApi"]
