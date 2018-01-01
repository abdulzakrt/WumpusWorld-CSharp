:- dynamic([ispit/1,
    iswumpus/1],
    nopit/1,
    nowumpus/1).

sensebreeze(aTrue,[X,Y]):-
    A1 is X+1 , (nopit([A1,Y]);assert(ispit([A1,Y]))), 
    A2 is X-1 , (nopit([A2,Y]);assert(ispit([A2,Y]))),
    A3 is Y-1 , (nopit([X,A3]);assert(ispit([X,A3]))),
    A4 is Y+1 , (nopit([X,A4]);assert(ispit([X,A4]))).

sensebreeze(aFalse,[X,Y]):- 
    A1 is X+1 , retractall(ispit([A1,Y])), assert(nopit([A1,Y])),
    A2 is X-1 , retractall(ispit([A2,Y])), assert(nopit([A2,Y])),
    A3 is Y-1 , retractall(ispit([X,A3])), assert(nopit([X,A3])),
    A4 is Y+1 , retractall(ispit([X,A4])), assert(nopit([X,A4])). 

sensestench(aTrue,[X,Y]):- 
    A1 is X+1 , (nowumpus([A1,Y]);assert(iswumpus([A1,Y]))),
    A2 is X-1 , (nowumpus([A2,Y]);assert(iswumpus([A2,Y]))),
    A3 is Y-1 , (nowumpus([X,A3]);assert(iswumpus([X,A3]))),
    A4 is Y+1 , (nowumpus([X,A4]);assert(iswumpus([X,A4]))).

sensestench(aFalse,[X,Y]):- 
    A1 is X+1 , retractall(iswumpus([A1,Y])), assert(nowumpus([A1,Y])),
    A2 is X-1 , retractall(iswumpus([A2,Y])), assert(nowumpus([A2,Y])),
    A3 is Y-1 , retractall(iswumpus([X,A3])), assert(nowumpus([X,A3])),
    A4 is Y+1 , retractall(iswumpus([X,A4])), assert(nowumpus([X,A4])).
	
/*sd*/