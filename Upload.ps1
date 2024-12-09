$packDir = "pack"

$version = Read-Host "请输入版本号（形如 1.0.0）"
$token = Read-Host "请输入 GitHub Token"

vpk upload github `
    -o $packDir --repoUrl 'https://github.com/albedo-geo/VelopackDemo' --token $token `
    --publish --releaseName "Velopack Demo v$version" --tag "v$version"