cleanall:
	sudo rm -rf bin obj
	dotnet clean
	dotnet build -f net9.0-maccatalyst
	xattr -rc ./bin/Debug/net9.0-maccatalyst/maccatalyst-arm64/Aurora.app || true
	dotnet build -t:Run -f net9.0-maccatalyst