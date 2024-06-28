# DomainCheck
---
 > [!CAUTION]
 > After installation don't forget to add DomainCheck to your shell path!
---

## Description
This simple command-line tool is for checking domain availability. \
It currently has limited number of domain endings. \
You can check for multiple domain endings like this: `domain_name.com+.net+.org`

![Screenshot of checking test using standard wildcard](https://github.com/Adisol07/domaincheck/blob/main/screenshot1.jpeg?raw=true)

## Wildcards
Example: `domain_name.#`
 - .@ -> checks all endings
 - .# -> checks standard endings
 - .$ -> checks shop-like endings
 - .! -> checks country endings
 - ._ -> checks other endings

## Installation
Download executible directory from github based on your platform \
e.g https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/osx-arm64/ \
Then you need to add the binary to your shell path. 

### Guide for specific operating systems:
#### Windows
Download either win-x64 or win-arm from github. \
Links: 
 - win-64x -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/win-x64
 - win-arm -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/win-arm64
   
Then put that folder somewhere on your system and create a shortcut for file `domaincheck.exe` \
Put this shortcut to `C:\Windows\System32`
#### MacOS
Download either osx-x64 or osx-arm from github. \
Links: 
 - osx-64x -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/osx-x64
 - osx-arm -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/osx-arm64
   
Then put that folder somewhere on your system. \
Then run this command in terminal: `echo "export PATH=\"{folder_location}/domaincheck\"" >> ~/.zshrc` (ZSH is most common but you can change shell) \
Then restart terminal.

#### Linux
Download either linux-x64 or linux-arm from github. \
Links: 
 - linux-64x -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/linux-x64
 - linux-arm -- https://github.com/Adisol07/domaincheck/tree/main/bin/Release/net8.0/linux-arm64
   
Then put that folder somewhere on your system. \
Then run this command in terminal: `echo "export PATH=\"{folder_location}/domaincheck\"" >> ~/.bashrc` (Bash is most common but you can change shell) \
Then restart terminal.

## License and usage
You can use this tool and its source code how you like. \
No restrictions or licenses.

## Supported domain endings
If you want to add a domain ending, create an issue here on github with title: "Domain ending request: [domain ending]"
#### List: 
 - com
 - net
 - org
 - io
 - app
 - ai
 - online
 - tech
 - me
 - shop
 - store
 - eu
 - us
 - uk
 - de
 - ru
 - ua
 - au
 - cz
 - be
 - ca
 - cf
 - sk
 - cg
 - fi
 - fr
 - gl
 - hk
 - jp
 - ml
 - nz
 - blog
 - company
 - cool
 - country
 - coupons
 - dentist
 - earth
 - edu
 - email
 - energy
 - gift
 - life
 - link
 - media
 - menu
 - movie
 - network
 - porn
 - repair
 - report
 - run
 - sale
 - school
 - science
 - search
 - secure
 - security
 - sex
 - software
 - solar
 - song
 - space
 - today
 - toys
 - travel
 - video
 - vip
 - watch
 - website
 - weather
 - webcam
 - wiki
 - work
 - xxx
 - xyz
 - zip
