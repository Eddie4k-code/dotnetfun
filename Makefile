MIGRATION_NAME :=

migrate:
	dotnet ef migrations add $(MIGRATION_NAME) && \
	dotnet ef database update
