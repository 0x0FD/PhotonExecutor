# finnaly new c# bootstrapper
# IM TIRED OF THAT SHITTY PYTHON FILE TO EXE CONVERTERS AND THAT SHITTY ANTI VIRUS APPS
# if you dunno coding i explained every thing
# HERE, SOURCE CODE:
import os
from zipfile import ZipFile
import subprocess
import requests
from pathlib import Path
from io import BytesIO
import shutil

# CONFIG
VERSION_URL = "https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/version.txt"
APP_URL = "https://raw.githubusercontent.com/FXSploit/PhotonExecutor/refs/heads/main/PhotonExecutor.zip"
APP_FOLDER = Path(os.getenv("APPDATA")) / "PhotonExc" # this shit makes anti viruses sus ( maybe? )
EXE_PATH = APP_FOLDER / "PhotonExecutor.exe"          # i dunno but this one too ig
VERSION_FILE = APP_FOLDER / "version.txt"


def check_if_installed():
    if EXE_PATH.exists(): # check if its already downloaded 
        print("[ SET ] Installed")
        return True
    return False


def check_update():
    print("[ BOOTSTRAPER ] Checking update...")

    if not VERSION_FILE.exists(): # check if version.txt exist if not install
        return False

    installed_version = VERSION_FILE.read_text().strip() # read version.txt
    cloud_version = requests.get(VERSION_URL).text.strip() # read version.txt (From Github to get the latest version)

    print(f"[ BOOTSTRAPER ] CloudVer: {cloud_version} | InstalledVer: {installed_version}")

    if cloud_version == installed_version: # if cloud and local version mathces pass
        print("[ BOOTSTRAPER ] Up-to-Date!")
        return True
    else:
        print("[ BOOTSTRAPER ] Outdated!")
        return False # ELSE: install latest version


def install(update=False):
    if update and APP_FOLDER.exists(): # if already installed remove old one
        print("[ BOOTSTRAPER ] Removing old version...")
        shutil.rmtree(APP_FOLDER) # destroy old folder/children 

    print("[ BOOTSTRAPER ] Creating folder...")
    APP_FOLDER.mkdir(parents=True, exist_ok=True) # create directories 

    print("[ BOOTSTRAPER ] Downloading ZIP...") # SECOND SHITTY REASON THAT MAKES ANTI VIRUSES GO BRRR BRRRR 
    response = requests.get(APP_URL) # Download latest version as .ZIP
    response.raise_for_status() # check status

    print("[ BOOTSTRAPER ] Extracting ZIP...")
    with ZipFile(BytesIO(response.content)) as zip_ref: # extract that f*cking zip file
        zip_ref.extractall(APP_FOLDER) 

    cloud_version = requests.get(VERSION_URL).text.strip() # write version.txt to match version.txt
    VERSION_FILE.write_text(cloud_version)

    print("[ DONE ] Installed / Updated.") # thats all


def runapp():
    print("[ BOOTSTRAPER ] Done!")
    print("[ BOOTSTRAPER ] Run app...")
    subprocess.Popen(str(EXE_PATH)) # run app / this also makes anti viruses go brrr ...


if __name__ == "__main__": # main function ...
    print("[ BOOTSTRAPER ] Start...") 

    if not check_if_installed():
        print("[ BOOTSTRAPER ] Installing...")
        install()
    else:
        if not check_update():
            install(update=True)

    runapp() # run.
