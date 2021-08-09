#!/usr/bin/env sh

# 确保脚本抛出遇到的错误
set -e

cd ../source/Amiable.Core
# 进入源代码包
cp -r Events ../../core-source/Amiable.Core/
cp -r Service ../../core-source/Amiable.Core/
cp -r Exports ../../core-source/Amiable.Core/
# 复制三个文件夹
cd ../../core-source

git init
git add -A
git commit -m 'deploy'



# 如果发布到 https://<USERNAME>.github.io/<REPO>
git push -f git@github.com:heerheer/Amiable.git master:core
cd -