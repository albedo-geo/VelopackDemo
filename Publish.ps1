$publishDir = "publish"
$packDir = "pack"

if (Test-Path $publishDir) {
	Remove-Item $publishDir -Recurse -Force
}

if (Test-Path $packDir) {
	Remove-Item $packDir -Recurse -Force
}

dotnet publish .\VelopackDemo\VelopackDemo.csproj -c Release -o $publishDir

# 输入版本号
$version = Read-Host "请输入版本号（形如 1.0.0）"

vpk pack -u VelopackDemo -v $version -p $publishDir -e VelopackDemo.exe -o $packDir -i VelopackDemo\icon.ico `
--packAuthors Albedo --delta None