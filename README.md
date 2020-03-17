# MageQuest

by Luís Eduardo Rozante

## Introduction

MageQuest was one of my very first proper attempts of a game back in 2012 when I was twelve years old and trying to learn how to make a game for the first time. I have tryed remaking it some times before but never got a really good reason to go through to the end. That's when I learned about [Improve my Game Jam](https://itch.io/jam/imgj8), this made me go back to my ideas of remaking the game and gave me a reason to finally finish it.

## The Process

### Before the jam

As the project was really old I decided to test if it still worked a week before the jam.

#### 2020-03-17

1. First of all I had to find the original game files, it was surprisingly easy even with the project being untouched for at least five years, I am very organanized with my backups so it was right where I tought it would be, but turns out bigger problems were coming...

2. **Update Unity Saga** 
   
One of the things I wanted to do was to update the project's Unity version. For what I can tell the original was last opened with Unity 3.5.5 and I am currently using Unity 2019.4.5. YES! There was 2016 major versions of Unity between now and back then!!! **Jokes aside,** there were only 5, but that was still a big challenge.

First I tried to go straight to the current version of Unity, as expected it didn't work: pretty much all references between assets were broke and terrain assets appear to have being corrupted.

Them I tried to download the old Unity 3.5.5 to check if the project was still okay, you can download and install it fine, but the activation can't be easily performed anymore, the online activation service is long dead and manual activation seems to throw an error at me every time, maybe I could attempt contacting Unity support, but skiping to Unity 4 appeared to be a better choice.

Activating Unity 4 was a lot easier, it appears to use the same activation system as current Unity versions, but for some reason the original Unity 4.0.0 always crashed when opening the project. Fortunately, Unity 4.7.2 (Last Unity 4 release) worked.

But the worse appeared to have happened: the project was still messed up and I wondered if it was lost forever! Thankfully I was able to figure it out, I had deleted the Library folders from my older projects so they take less space in storage, it's fine whith newer version, as the folder will simply be regenerated, but it appears to mess up the older ones. I did it recently so I still had the original Library folders in a secondary backup for safety, I put the original folders back and it worked fine!

I tried 3 to 2019 again in case that was also the problem and the project still got messed up, but at least I was sure the project still appeared to work so I decided to try two things in paralel:

    I. Going major version to major version one at a time - that got me to downloading Unity 5.6.7 (Currently the last Unity 5 version, surprisingly released in 2019, the original 5 version came out in early 2015)

    II. Trying to make the biggest jump possible - as I knew 2019 wouldn't work, I decided to try updating 3.5.5 to 2017.4.37, something was telling me 2018 would be too much.

Updating 4 to 5 went fine, but 3 to 2017 also worked, so I ended up abandoning the first route to avoid having to go 5 to 2017, them I tried going from 2017.4.37 to 2018.4.19 and it also worked, finally I went 2018.4.19 to 2019.3.5 (Current version) finishing the process with success!

I went back and tried to update 3.5.5 directly to 2018.4.19 to see if I could cut out one step but I got the same problem when updating directly to 2019, turns out my intuition was right and the problem breaking the Unity 3 project appears to be somewhere in the 2018 release. Maybe I could try cutting out 2018 by going 2017 straight to 2019 but it had already taken too long, so the final process was:

    3.5.5 -> 2017.4.37 -> 2018.4.19 -> 2019.3.5

3. **The misterious disappearing of JavaScript**: Back in the day you could code your Unity games using JavaScript (there was also a thing called BooScript, but I've never seen someone actually using it), but tough the project worked great for the most part, for some reason all code written in  JavaScript had dissapeared!!! Unity cut support for it a couple versions ago, but it will automaticaly try converting old code to C# if you want, so I wondered if something went wrong with the conversion and the files went missing. Turns out the files are gone from the original project too! I don't know what exactly, but something hapenned in the previous years that deleted all my code! This will probably remain a mistery forever, but fortunatly I coded it when I was 12 and was just learning, so now a it's pretty easy task to me and I can quickly remake all I had lost, I don't have a lot more time today so I will leave this for another time.

4. NOTE: I also deleted some music that was probably copyrighted from the project, I didn't knew how those things worked back them and I have no clue where I originally got it, so it's better to be gone without it.

