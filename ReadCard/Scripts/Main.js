(function (d, w, u) {
    var canvas = d.getElementById('sketch');
    var ctx = canvas.getContext("2d");
    var width = window.innerWidth;
    var height = window.innerHeight;
    var slash = [];
    var nb = 15;
    var colors = ['#50a68e', '#d64545'];

    // Draw Function
    function quad(ax, ay, bx, by, cx, cy, dx, dy) {
        ctx.beginPath();
        ctx.moveTo(ax, ay);
        ctx.lineTo(bx, by);
        ctx.lineTo(cx, cy);
        ctx.lineTo(dx, dy);
        ctx.closePath();
    }

    // Math Functions
    function random(min, max) {
        return min + Math.random() * (max - min);
    }

    function int(n) {
        return Math.floor(n);
    }

    function ease(value, target, easingVal) {
        var d = target - value;
        if (Math.abs(d) > 1) value += d * easingVal;
        return value;
    }

    // Slash Class
    var SlashTaille = 35;
    var SlashDelta = 240;

    var Slash = function (_c) {
        this.c = _c;
        this.x1 = 0;
        this.x2 = 0;
        this.y1 = 0;
        this.y2 = 0;
        this.tarX1 = 0;
        this.tarX2 = 0;
        this.tarY1 = 0;
        this.tarY2 = 0;
        this.easing = 0.03;
        this.timer = 0;
        this.tMax = 0;
        this.vertical = true;
    };

    Slash.prototype.init = function () {
        this.easing = random(0.01, 0.1);
        this.timer = 0;
        this.tMax = random(60, 150);
        this.vertical = Math.random() > 0.5;
        this.x1 = this.x2 = int(random(1, int(width / 40) - 1)) * 40;
        this.y1 = this.y2 = int(random(1, int(height / 40) - 1)) * 40;

        if (this.x1 < width / 2) this.tarX2 = this.x1 + SlashDelta;
        else this.tarX2 = this.x1 - SlashDelta;

        if (this.y1 < height / 2) this.tarY2 = this.y1 + SlashDelta;
        else this.tarY2 = this.y1 - SlashDelta;
    };

    Slash.prototype.update = function () {
        this.x2 = ease(this.x2, this.tarX2, this.easing);
        this.y2 = ease(this.y2, this.tarY2, this.easing);
        if (Math.abs(this.x2 - this.tarX2) <= 1) {
            this.timer++;

            if (this.timer > this.tMax) {
                this.tarX1 = this.tarX2;
                this.tarY1 = this.tarY2;
                this.x1 = ease(this.x1, this.tarX1, this.easing);
                this.y1 = ease(this.y1, this.tarY1, this.easing);

                if (Math.abs(this.x1 - this.tarX1) <= 1) {
                    this.init();
                }
            }
        }
    };

    Slash.prototype.draw = function () {
        ctx.fillStyle = this.c;
        if (this.vertical) quad(this.x1, this.y1 - SlashTaille, this.x1, this.y1 + SlashTaille, this.x2, this.y2 + SlashTaille, this.x2, this.y2 - SlashTaille);
        else quad(this.x1 - SlashTaille, this.y1, this.x1 + SlashTaille, this.y1, this.x2 + SlashTaille, this.y2, this.x2 - SlashTaille, this.y2);
        ctx.fill();
    };

    // Starter
    function init() {
        canvas.width = width;
        canvas.height = height;
        for (var i = 0; i < nb; i++) {
            slash.push(new Slash(colors[i % 3]));
        }

        ctx.shadowOffsetX = 3;
        ctx.shadowOffsetY = 3;
        ctx.shadowBlur = 5;
        ctx.shadowColor = "black";
    }

    function animate() {
        w.requestAnimationFrame(animate);
        ctx.clearRect(0, 0, width, height);

        for (var i = 0; i < nb; i++) {
            slash[i].update();
            slash[i].draw();
        }
    }

    canvas.onmouseup = function (e) {
        for (var i = 0; i < nb; i++) {
            slash[i].init();
        }
    };

    window.onresize = function (e) {
        width = window.innerWidth;
        height = window.innerHeight;
        canvas.width = width;
        canvas.height = height;
    };

    init();
    animate();
})(document, window, undefined);