# peiper-api
api for peiper.se

# To publish 
dotnet publish -r linux-arm -o d:\git\peiper-api\publish

# To run
systemctl start kestrel-api.service
systemctl restart kestrel-api.service
systemctl stop kestrel-api.service