# MageQuest

by Luís Eduardo Rozante

## Introduction

MageQuest was one of my very first proper attempts of a game back in 2012, I was twelve years old and trying to learn how to make a game for the first time. I1ve tried remaking and finishing it before but never got a really good reason to go through to the end. That's when I learned about [Improve my Game Jam](https://itch.io/jam/imgj8), this made me go back to my ideas of redoing it and gave me the much needed reason to finally complete it.

## Jam Improvements

Here I will list what was improved during the jam after the end

## The Process

### Before the jam

As the project was really old I decided to test if it still worked about a week before the jam. What I did will be detailed below.

#### 2020-03-17

First of all I had to find the original game files, it was surprisingly easy even with the project being untouched for six years, I am very organanized with my backups so it was right where I tought it would be, unfortunatly the original builds were lost, but it was alright because I at least had the project didn't I? Well, turns out bigger problems were coming...

**Updating Unity Saga** 
   
One of the things I wanted to do was to update the project's Unity version. For what I can tell the original was last opened with Unity 3.5.5 and I am currently using Unity 2019.4.5. YES! There was 2016 major versions of Unity between now and back then!!! **Jokes aside,** there were only 5, but that was still a big challenge.

First I tried to go straight to the current version of Unity, as expected it didn't work: pretty much all references between assets were broken and terrain assets appear to have being corrupted.

Then I tried to download the old Unity 3.5.5 to check if the project was still okay, you can download and install it fine, but the activation can't be easily performed anymore, the online activation service is long dead and manual activation seems to throw an error at me every time, maybe I could attempt contacting Unity support, but skiping to Unity 4 appeared to be a better choice.

Activating Unity 4 was a lot easier, it appears to use the same activation system as current Unity versions, but for some reason the original Unity 4.0.0 always crashed when opening the project. Fortunately, Unity 4.7.2 (Last Unity 4 release) worked.

But the worse appeared to have happened: the project was still messed up and I wondered if it was lost forever! Thankfully I was able to figure it out, I had deleted the Library folders from my older projects so they take less space in storage, it's fine whith newer version, as the folder will simply be regenerated, but it appears to mess up the older ones. I did it recently so I still had the original Library folders in a secondary backup for safety, I put the original folders back and it worked fine, well mostrly...

I tried 3 to 2019 again in case that was also the problem and the project still got messed up, but at least I was sure the project still appeared to work so I decided to try two things in paralel:

**I.** Going major version to major version one at a time - that got me to downloading Unity 5.6.7 (Currently the last Unity 5 version, surprisingly released in 2019, the original 5 version came out in early 2015)

**II.** Trying to make the biggest jump possible - as I knew 2019 wouldn't work, I decided to try updating 3.5.5 to 2017.4.37, something was telling me 2018 would be too much.

Updating 4 to 5 went fine, but 3 to 2017 also worked, so I ended up abandoning the first route to avoid having to go 5 to 2017, them I tried going from 2017.4.37 to 2018.4.19 and it also worked, finally I went 2018.4.19 to 2019.3.5 (Current version) finishing the process with success!

I went back and tried to update 3.5.5 directly to 2018.4.19 to see if I could cut out one step but I got the same problem when updating directly to 2019, turns out my intuition was right and the problem breaking the Unity 3 project appears to be somewhere in the 2018 release. Maybe I could try cutting out 2018 by going 2017 straight to 2019 but it had already taken too long, so the final process was:

`3.5.5 -> 2017.4.37 -> 2018.4.19 -> 2019.3.5`

**The misterious disappearing of JavaScript:** As said before, the process went only *mostly* fine: back in the day you could code your Unity games using JavaScript (there was also a thing called BooScript, but I've never seen someone actually using it), turns out for some reason all code written in JavaScript had dissapeared!!! Unity cut support for it a couple versions ago, but it will automaticaly try converting old code to C# if you want, so I wondered if something went wrong with the conversion and the files went missing. Turns out the files are gone from the original project too! I don't know what exactly, but something hapenned in the previous years that deleted all my code! This will probably remain a mistery forever, but fortunatly I coded it when I was 12 and was just learning, so now it's a pretty easy task to me and probably can quickly remake what I've lost, I'm out of time for today, so I will leave this for tomorrow.

**NOTE:** I also deleted some music that was probably copyrighted from the project, I didn't knew how those things worked back them and I have no clue where I originally got it, so it's better to go without it.

#### 2020-03-18

Today I tried rewriting the code I lost, only a couple scripts that I had converted to C# during my first remake attempt survived, mostly related to player and enemy movimentation, player life and mana systems along with all the spells were redone from scratch. Also the menus had to be remade, current Unity UI system didn't exist at the time and the ancient UI I used was entirely inside the lost scripts. Fortunatly some text regarding the original plot survived, it was written in some different text components, those were also deprecated, but they survived in the original project, so I went back to Unity 4 in order to retrieve the writing, I also translated the game to english because of the jam, the original one was in portuguese. Outside of that I only did a couple more improvements and fixes.

I also realised I had started working on a second level I hadn't actually released on the original version even with it being pretty much done, the third and final level tough is completly empty, and it's not worth finishing before the jam.

It's not perfectly like the original builds and I wish I still had them, but it's probably as close as it can get, it retains the amateurish and poorly made feel from the original, and it shows me the potential I had if I kept studying. 8 years and a lot of study and experience later and I'm about to try remaking the game in very little time. I'm not touching the project again until the start of the jam, but I will be making and releasing a build to have something to compare the remade project when it's done.

### The Jam

#### 2020-03-21

I ended up not working the first day of the jam due to some things from uni and also because I wasn't in the mood due to the COVID-19 prospects in Brazil... But well, here I am, thinking where to start, guess it will be: trowing away the entire project! Ok, I will keep using the old project, so I can have it as a reference, but I'm pretty much redoing it from scratch, the only reason I was trying to update and fix it the days before was to have a build of the older version as I lost the originals. I'm basicly creating an "Old" folder and putting the original inside it, this makes for some of the files being inside two "Old" folders, because that's exactly what I did in 2014 when I tried remaking for the first time.  