

// zelf geschreven!!

var winsTeam = parseInt(document.getElementById('getWins').innerHTML);
var losesTeam = parseInt(document.getElementById('getLoses').innerHTML);
var drawsTeam = parseInt(document.getElementById('getDraws').innerHTML);


//data cirkeldiagrammen vullen

var data = [
{
    value: winsTeam,
    color: "#F7464A",
    highlight: "#FF5A5E",
    label: "Win"
},
{
    value: drawsTeam,
    color: "#46BFBD",
    highlight: "#5AD3D1",
    label: "Draw"
},
{
    value: losesTeam,
    color: "#FDB45C",
    highlight: "#FFC870",
    label: "Lose"
}
]

// het canvas vullen
var ctx = document.getElementById("myChart").getContext("2d");

var myDoughnutChart = new Chart(ctx).Doughnut(data);

// data fut teams 

var data2 = [
{
    value: 100,
    color: "#F7464A",
    highlight: "#FF5A5E",
    label: "Win"
},
{
    value: 50,
    color: "#46BFBD",
    highlight: "#5AD3D1",
    label: "Draw"
},
{
    value: 100,
    color: "#FDB45C",
    highlight: "#FFC870",
    label: "Lose"
}
]
var ctx2 = document.getElementById("myChart2").getContext("2d");

var myDoughnutChart2 = new Chart(ctx2).Doughnut(data2);




// kleur, breedte zetten van de de progress bar

function setPointColor(color, hoverColor,  widthPoints){
    var cssAnimation = document.createElement('style');
    cssAnimation.type = 'text/css';

    var keyFramePrefixes = ["-webkit-", "-o-", "-moz-", ""];
    var keyFrames = [];
    var textNode = null;

    for (var i in keyFramePrefixes) {

        keyFrames = '@' + keyFramePrefixes[i] + 'keyframes load {' +
        '0% { width: 0 ; background-color : #4E4E4E;}' +
        '100% { width:' + widthPoints + ' ; background-color : ' + color + ';}';

        textNode = document.createTextNode(keyFrames);

        cssAnimation.appendChild(textNode);

        document.getElementsByTagName("head")[0].appendChild(cssAnimation);
    }

    $('.point-progress').css('background-color', color);

    $('.point-progress').hover(function () {
        $('.point-progress').css('background-color', hoverColor);
        $('.points-now').show();
    }, function () {
        $('.point-progress').css('background-color', color);
        $('.points-now').hide();
    });
}


// de divisies bepalen van de speler, het punten systeem bepalen aan de hand van de data
function whatDivision(division, pointsHold, pointsPromotion,pointsTitle, maxPoints)
{
    var maxWidth = 400;

    var pxOnePoint = maxWidth / maxPoints;
    var widthPointsNow = pointsNow * pxOnePoint;

    if (division >= 1 && division <= 10) {
        
        if (division == 1) {
            if (divisionNow == division) {
                if (pointsNow < pointsHold) {
                    setPointColor('#F7464A', '#FF5A5E', widthPointsNow);
                }
                else if (pointsNow >= pointsHold && pointsNow < pointsTitle) {
                    setPointColor('#4E4E4E', '#707070', widthPointsNow);
                }
                else if (pointsNow >= pointsTitle && pointsNow <= maxPoints) {
                    setPointColor('#FDB45C', '#FFC870', widthPointsNow);
                }
                else if (pointsNow > maxPoints) {
                    pointsNow = maxPoints;

                    widthPointsNow = pointsNow * pxOnePoint;

                    setPointColor('#FDB45C', '#FFC870', widthPointsNow);
                }
                else {
                    console.log('de waarde klopt niet');
                }
            }
        }
        else if (division == 10) {
            if (pointsNow >= pointsHold && pointsNow < pointsPromotion) {
                setPointColor('#4E4E4E', '#707070', widthPointsNow);
            }
            else if (pointsNow >= pointsPromotion && pointsNow < pointsTitle) {
                setPointColor('#46BFBD', '#5AD3D1', widthPointsNow);
            }
            else if (pointsNow >= pointsTitle && pointsNow <= maxPoints) {
                setPointColor('#FDB45C', '#FFC870', widthPointsNow);
            }
            else if (pointsNow > maxPoints) {
                pointsNow = maxPoints;

                widthPointsNow = pointsNow * pxOnePoint;

                setPointColor('#FDB45C', '#FFC870', widthPointsNow);
            }
            else {
                console.log('de waarde klopt niet');
            }
        }
        else {

            if (divisionNow == division) {
                
                console.log('hij zit hier + '+pointsNow);
                if (pointsNow < pointsHold) {
                    setPointColor('#F7464A', '#FF5A5E', widthPointsNow);
                }
                else if (pointsNow >= pointsHold  && pointsNow < pointsPromotion) {
                    setPointColor('#4E4E4E', '#707070', widthPointsNow);
                }
                else if (pointsNow >= pointsPromotion && pointsNow < pointsTitle) {
                    setPointColor('#46BFBD', '#5AD3D1', widthPointsNow);
                }
                else if (pointsNow >= pointsTitle && pointsNow <= maxPoints) {
                    setPointColor('#FDB45C', '#FFC870', widthPointsNow);
                }
                else if (pointsNow > maxPoints) {
                    pointsNow = maxPoints;

                    widthPointsNow = pointsNow * pxOnePoint;

                    setPointColor('#FDB45C', '#FFC870', widthPointsNow);
                }
                else {
                    console.log('de waarde klopt niet');
                }
            }
        }
    }
    $('.point-progress').width(widthPointsNow);
}

// divisies limieten zetten

function setDivision(divisionNow) {
    switch(divisionNow)
    {
        case 1:
            whatDivision(1, 14, 0, 22, 23);
            break;
        case 2:
            whatDivision(2, 12, 18, 21, 22);
            break;
        case 3:
            whatDivision(3, 12, 18, 21, 22);
            break;
        case 4:
            whatDivision(4, 10, 16, 19, 20);
            break;
        case 5:
            whatDivision(5, 10, 16, 19, 20);
            break;
        case 6:
            whatDivision(6, 10, 16, 19, 20);
            break;
        case 7:
            whatDivision(7, 8, 14, 17, 18);
            break;
        case 8:
            whatDivision(8, 8, 12, 15, 16);
            break;
        case 9:
            whatDivision(9, 6, 10, 13, 14);
            break;
        case 10:
            whatDivision(10, 0, 9, 12, 13);
            break;
    }
}
// Slider + de de divisies zetten

var divisionNow = parseInt(document.getElementById('getDivision').innerHTML);

$(function () {
    pointsNow = parseInt(document.getElementById('getPoints').innerHTML);


    setDivision(divisionNow);

    $('.show-fut').hide();
    $('.right-slide').click(function () {
        // if team
        if ($('.show-teams').is(':visible')) {
            $('.show-teams').hide("fast");
            $('.show-fut').show("fast");

            pointsNow = document.getElementById('points-now-fut').innerHTML;

            setDivision(divisionNow);
        }
        //if fut
        else if($('.show-fut').is(':visible')) {
            $('.show-teams').show("fast");
            $('.show-fut').hide("fast");
            pointsNow = document.getElementById('points-now-team').innerHTML;

            setDivision(divisionNow);
        }
    });
});