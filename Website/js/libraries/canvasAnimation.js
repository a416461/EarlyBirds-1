/*
(function () {

    var hexagon_radius = 50;
    var hexagon_max_absolute_speed = 0.1;
    var hexagon_space_between = 2;
    var hexagon_line_width = 1;
    var hexagon_color = 'cyan';


    var canvas, ctx;

    var hexagons = [];

    var s3p3 = Math.sqrt(3);

    function init() {

        canvas = document.getElementById('mainDisp');
        canvas.width = window.innerWidth;
        canvas.height = window.innerHeight;
        canvas.style.width = canvas.width;
        canvas.style.height = canvas.height;
        ctx = canvas.getContext('2d');

        ctx.globalCompositeOperation = "source-over";

        var hw = Math.ceil(canvas.width / (1.5 * hexagon_radius + hexagon_space_between * 2)) + 1;
        var hh = Math.ceil(canvas.height / (s3p3 * hexagon_radius + hexagon_space_between * 2)) + 1;

        for (var x = 0; x < hw; x++)
            for (var y = 0; y < hh; y++)
                addHexagon(
                     hexagon_radius + hexagon_space_between + (1.5 * hexagon_radius + hexagon_space_between * 2) * x,
                    s3p3 * hexagon_radius / 2 + hexagon_space_between + (s3p3 * hexagon_radius + hexagon_space_between * 2) * y - (x % 2 ? s3p3 * hexagon_radius / 2 : 0),
                    {
                        l: 0
                    }
                );

        ctx.lineWidth = hexagon_line_width;

        loop();

    }

    function loop() {
        requestAnimFrame(loop);

        ctx.clearRect(0, 0, canvas.width, canvas.height);
        ctx.fillStyle = '#171717';
        ctx.fillRect(0, 0, canvas.width, canvas.height);

        ctx.beginPath();

        for (var i = 0; i < hexagons.length; i++)
            drawHexagonPath(i);

        ctx.shadowColor = hexagon_color;
        ctx.shadowBlur = 20;
        ctx.strokeStyle = hexagon_color;
        ctx.stroke();

    }

    function addHexagon(x, y, opts) {
        var l = Math.floor(Math.random() * 6),
            p = Math.random();

        if (!opts) opts = {};

        hexagons.push({
            sl: opts.l || opts.l === 0 ? opts.l : l,
            p: opts.p || opts.p === 0 ? opts.p : p,
            x: x,
            y: y,
            speed: opts.speed || opts.speed === 0 ? opts.speed : (Math.random() * hexagon_max_absolute_speed * 2 - hexagon_max_absolute_speed)
        });
    }

    function drawHexagonPath(hex_index) {

        var hex = hexagons[hex_index];



        ctx.moveTo(
            hex.x + Math.cos(Math.PI / 3 * hex.sl) * hexagon_radius + Math.cos(Math.PI / 3 * (hex.sl + 2)) * hexagon_radius * hex.p,
            hex.y + Math.sin(Math.PI / 3 * hex.sl) * hexagon_radius + Math.sin(Math.PI / 3 * (hex.sl + 2)) * hexagon_radius * hex.p
        );

        //ctx.moveTo(hex.x, hex.y);

        ctx.lineTo(
            hex.x + Math.cos(Math.PI / 3 * (hex.sl + 1)) * hexagon_radius,
            hex.y + Math.sin(Math.PI / 3 * (hex.sl + 1)) * hexagon_radius
        );

        ctx.lineTo(
            hex.x + Math.cos(Math.PI / 3 * (hex.sl + 2)) * hexagon_radius,
            hex.y + Math.sin(Math.PI / 3 * (hex.sl + 2)) * hexagon_radius
        );

        ctx.lineTo(
            hex.x + Math.cos(Math.PI / 3 * (hex.sl + 3)) * hexagon_radius,
            hex.y + Math.sin(Math.PI / 3 * (hex.sl + 3)) * hexagon_radius
        );

        ctx.lineTo(
            hex.x + Math.cos(Math.PI / 3 * (hex.sl + 3)) * hexagon_radius + Math.cos(Math.PI / 3 * (hex.sl + 5)) * hexagon_radius * hex.p,
            hex.y + Math.sin(Math.PI / 3 * (hex.sl + 3)) * hexagon_radius + Math.sin(Math.PI / 3 * (hex.sl + 5)) * hexagon_radius * hex.p
        );

        hex.p += hex.speed;
        if (hex.p > 1 || hex.p < 0) {
            hex.p = hex.speed < 0 ? 1 : 0;
            hex.sl += hex.speed < 0 ? -1 : 1;
            hex.sl = hex.sl % 6;
            hex.sl = hex.sl < 0 ? 4 - hex.sl : hex.sl;
        }

        hexagons[hex_index] = hex;

    }

    window.onload = function () {
        init();
    };

    window.requestAnimFrame = (function () {
        return window.requestAnimationFrame ||
                window.webkitRequestAnimationFrame ||
                window.mozRequestAnimationFrame ||
                function (callback) {
                    window.setTimeout(callback, 1000 / 60);
                };
    })();
})();
*/











/*
(function () {
    var c = document.getElementById("mainDisp"),
    $ = c.getContext('2d'),
    w = c.width,
    h = c.height,
    d, l,
    t = 0;

    function init() {
        reset();
        loop();
    }
    function draw() {
        var z = 15 - Math.sin(t) * 15 - Math.cos(t);
        $.fillStyle = 'rgba(0, 0, 0, 0.025)';
        $.fillRect(0, 0, w, h);
        for (var i = 0; i < l; i++) {
            var r = ((i * d / 3) / l) * Math.sin((z * 100) + i),
                x = Math.sin(i) * r + (w / 2),
                y = Math.cos(i) * r + (h / 2);
            $.beginPath();
            $.fillStyle = 'rgba(0, 255, 255, 1)';
            $.fillRect(x, y, 1, 1);
        }
        t += 0.00001;
    }

    function reset() {
        w = c.width = window.innerWidth;
        h = c.height = window.innerHeight;
        d = Math.min(w, h) - 50;
        l = Math.round(d / 10);
    }

    function loop() {
        requestAnimationFrame(loop);
        draw();
    }

    window.addEventListener('resize', reset);

    init();
})();
*/







// http://paulirish.com/2011/requestanimationframe-for-smart-animating/
// http://my.opera.com/emoller/blog/2011/12/20/requestanimationframe-for-smart-er-animating

// requestAnimationFrame polyfill by Erik Möller. fixes from Paul Irish and Tino Zijdel

// MIT license

/*
(function () {
    var lastTime = 0;
    var vendors = ['ms', 'moz', 'webkit', 'o'];
    for (var x = 0; x < vendors.length && !window.requestAnimationFrame; ++x) {
        window.requestAnimationFrame = window[vendors[x] + 'RequestAnimationFrame'];
        window.cancelAnimationFrame = window[vendors[x] + 'CancelAnimationFrame']
                                   || window[vendors[x] + 'CancelRequestAnimationFrame'];
    }

    if (!window.requestAnimationFrame)
        window.requestAnimationFrame = function (callback, element) {
            var currTime = new Date().getTime();
            var timeToCall = Math.max(0, 16 - (currTime - lastTime));
            var id = window.setTimeout(function () { callback(currTime + timeToCall); },
              timeToCall);
            lastTime = currTime + timeToCall;
            return id;
        };

    if (!window.cancelAnimationFrame)
        window.cancelAnimationFrame = function (id) {
            clearTimeout(id);
        };
}());
// ends requestAnimationFrame polyfill




var canvas = document.getElementById("mainDisp");
var cw = canvas.width = window.innerWidth;
var ch = canvas.height = window.innerHeight;
var ctx = canvas.getContext("2d");
//ctx.globalAlpha=0.5;
ctx.strokeStyle = "white";

var R = 300;
var r = 92;
var a = 0;

//ctx.arc(cw/2,ch/2,R,0,2*Math.PI);

var circRy = [];
var cL = 20;


for (var i = 0; i < cL; i++) {
    a += 18;

    for (var k = 0; k < 20; k++) {
        var p = k * cL + i;
        var span = 10 * k;
        circRy[p] = {}
        circRy[p].a = (Math.PI / 180) * a;
        circRy[p].x = cw / 2 + (R - span) * Math.cos(circRy[p].a);
        circRy[p].y = ch / 2 + (R - span) * Math.sin(circRy[p].a);
    }

}
var c = circRy.length;



function draw() {

    c--;
    if (c >= 0) {
        ctx.beginPath();
        ctx.moveTo(circRy[c].x + r, circRy[c].y);
        ctx.arc(circRy[c].x, circRy[c].y, r, 0, 2 * Math.PI);
        ctx.stroke();


        requestId = window.requestAnimationFrame(draw);
    }
}

function start() {
    requestId = window.requestAnimationFrame(draw);
    stopped = false;
}
function stopAnim() {
    if (requestId) {
        window.cancelAnimationFrame(requestId);
    }
    stopped = true;
}


function cleanSlate() {
    ctx.clearRect(0, 0, cw, ch);
    stopped = true;
    start();
    //window.setTimeout(function(){stopAnim();},6200);
}
window.onload = start();
canvas.addEventListener("click", function () { (stopped == true) ? start() : stop(); }, false)
*/