-> start

=== start ===

Now we are running Ink!
...
And here is another line.

+ [here is one choice] -> choice_1
+ [here is another choice] -> choice_2

- (choice_1)
You selected the first choice!
-> continue

- (choice_2)
You selected the second choice!
-> continue

= continue
@printer Wide
@bgm Wind fade:1 wait:false
@spawn SunShafts params:0.5 wait:false
@back Desert time:1
@wait 1
@char n pos:75,-100 time:0
@hide n time:0
@sfx Paper volume:0.5
@char n pos:75,-85
@wait 1.5
@sfx FabricRightToLeft
@wait 0.15
@char n look:right pos:25,-75
@wait 0.35
@sfx Paper
@spawn ShakeCharacter params:n,1,0.3,0,0.5,0
@wait 0.5
@sfx Paper
@char n look:left pos:35,-80
@stopSfx Paper wait:false
...
@hidePrinter 
@sfx FabricLeftToRight
@wait 0.15
@char n look:right pos:85,-55
@wait 0.5
@sfx Paper volume:0.5
@char n look:left pos:85,-45
@sfx Paper
@char n.Surprise wait:false
@spawn ShakeCharacter params:n,1,0.15,0,0.3,0 wait:false
@wait 0.5
@char n.Default pos:50,-10 wait:false
@stopBgm Wind fade:5 wait:false
@bgm CloudNine fade:1 wait:false
@wait 0.25
n: Oh, hey there!

+ [hello!] -> start