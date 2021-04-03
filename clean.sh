#!/bin/bash
# Fati Iseni

WorkingDir="$(pwd)"

########## Make sure you're not deleting your whole computer :)
safetyCheck()
{
if [[ ( "$WorkingDir" = "" || "$WorkingDir" = "/" || "$WorkingDir" = '/c' || "$WorkingDir" = '/d' || "$WorkingDir" = 'c:\' || "$WorkingDir" = 'd:\' || "$WorkingDir" = 'C:\' || "$WorkingDir" = 'D:\') ]]; then
	echo "Please cross check the WorkingDir value";
	exit 1;
fi
}

########## Delete .vs directories.
deleteDirs()
{
echo "Deleting .vs files and directories...";

find "$WorkingDir/" -type d -name ".vs" -exec rm -rf {} \; > /dev/null 2>&1;
}

########## Delete content of bin and obj directories.
deleteDirContents()
{

echo "Deleting content of bin and obj directories...";

for i in `find "$WorkingDir/" -type d -name "bin" | sort -r`; do rm -rf "$i"/*; done
for i in `find "$WorkingDir/" -type d -name "obj" | sort -r`; do rm -rf "$i"/*; done
}

########## Cleaning content in wwwroot folder of the web project
cleanWwwrootContent()
{

echo "Cleaning content in wwwroot folder of the web project...";
wwwroot="$(find "$WorkingDir/" -type d -name "wwwroot")"

if [[ "$wwwroot" != "" ]]; then
	rm -rf "$wwwroot/lib"/*;
	rm -rf "$wwwroot/dist"/*;
fi
}


safetyCheck;
echo "";

if [ "$1" = "dirs" ]; then
	deleteDirs;
elif [ "$1" = "contents" ]; then
	deleteDirContents;
elif [ "$1" = "wwwroot" ]; then
	cleanWwwrootContent
else
	deleteDirs;
	deleteDirContents;
fi
