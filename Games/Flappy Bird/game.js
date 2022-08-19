// SELECT CANVAS
const cvs = document.getElementById("bird");
const ctx = cvs.getContext("2d");

// GAME VARS AND CONSTS
let frames = 0;
const DEGREE = Math.PI/180;

// LOAD SPRITES IMAGES
const sprites = new Image();
sprites.src = "img/sprites.png";

// LOAD SOUNDS
const SCORE_S = new Audio();
SCORE_S.src = "audio/point.wav";

const FLAP = new Audio();
FLAP.src = "audio/flap.wav";

const HIT = new Audio();
HIT.src = "audio/hit.wav";

const SWOOSHING = new Audio();
SWOOSHING.src = "audio/swoosh.wav";

const DIE = new Audio();
DIE.src = "audio/die.wav";

// GAME STATE
let gamemodeSelected = 0;
var mayShortenGap = false;
var lowGravity = false;
var playingGamemode = 1;
const state = {
    current : 0,
    getReady : 0,
    game : 1,
    over : 2
}

// START BUTTON COORD
const startBtn = {
    x : 120,
    y : 263,
    w : 83,
    h : 29
}

// GAMEMODE SELECTION
function selectGamemode(gamemode){
    if(gamemode == 1){
        playingGamemode = 1;
        sprites.src = "img/sprites.png"
        pipes.gap = 100;
        bird.gravity = 0.22;
        bird.jump = 4.3;
        mayShortenGap = false;
        lowGravity = false;
    }
    if(gamemode == 2){
        playingGamemode = 2;
        sprites.src = "img/sprites_Red.png"
        pipes.gap = 140;
        bird.gravity = 0.22;
        bird.jump = 4.3;
        mayShortenGap = true;
        lowGravity = false;
    }
    if(gamemode == 3){
        playingGamemode = 3;
        sprites.src = "img/sprites_Blue.png"
        pipes.gap = 150;
        bird.gravity = 0.12;
        bird.jump = 4.6;
        mayShortenGap = false;
        lowGravity = true;
    }
}

// CHANGE BACKGROUND COLOR OF THE SELECTED "GAMEMODE" BUTTON
document.body.addEventListener('click', ({ target }) => {
    if (!target.matches('button')) {
      return;
    }
    target.style.backgroundColor = '#fcb700';
  }
);

// IF BUTTON CLICKED CHANGE ALL BUTTONS BACK TO ORIGNAL COLOR
document.body.addEventListener('click', ({ target }) => {
    if (target.matches('#button1')) {
        document.getElementById("button2").style.backgroundColor = 'white'
        document.getElementById("button3").style.backgroundColor = 'white'
    }
    else if (target.matches('#button2')) {
        document.getElementById("button1").style.backgroundColor = 'white'
        document.getElementById("button3").style.backgroundColor = 'white'
    }
    else if(target.matches('#button3')) {
        document.getElementById("button1").style.backgroundColor = 'white'
        document.getElementById("button2").style.backgroundColor = 'white'
    }
});


// CONTROL THE GAME
cvs.addEventListener("click", function(evt){
    document.getElementById('gamemodeButtons').style.visibility = 'hidden';

    switch(state.current){
        case state.getReady:
            state.current = state.game;
            SWOOSHING.play();
            break;
        case state.game:
            if(bird.y - bird.radius <= 0) return;
            bird.flap();
            FLAP.play();
            break;
        case state.over:
            let rect = cvs.getBoundingClientRect();
            let clickX = evt.clientX - rect.left;
            let clickY = evt.clientY - rect.top;
            
            // CHECK IF CLICKED ON THE START BUTTON
            if(clickX >= startBtn.x && clickX <= startBtn.x + startBtn.w && clickY >= startBtn.y && clickY <= startBtn.y + startBtn.h){
                pipes.reset();
                bird.speedReset();
                score.reset();
                state.current = state.getReady;
                document.getElementById('gamemodeButtons').style.visibility = 'visible';
            }
            break;
    }
});

// BACKGROUND
const bg = {
    sX : 0,
    sY : 0,
    w : 275,
    h : 226,
    x : 0,
    y : cvs.height - 226,
    
    draw: function(){
        ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
        
        ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x + this.w, this.y, this.w, this.h);
    }
    
}

// FOREGROUND
const fg = {
    sX: 276,
    sY: 0,
    w: 224,
    h: 112,
    x: 0,
    y: cvs.height - 112,
    
    dx : 2,
    
    draw: function(){
        ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
        
        ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x + this.w, this.y, this.w, this.h);
    },
    
    update: function(){
        if(state.current == state.game){
            this.x = (this.x - this.dx)%(this.w/2);
        }
    }
}

// BIRD
const bird = {
    animation: [
        {sX: 276, sY : 112},
        {sX: 276, sY : 139},
        {sX: 276, sY : 164},
        {sX: 276, sY : 139}
    ],
    x : 50,
    y : 150,
    w : 34,
    h : 26,
    
    radius : 10,
    
    frame : 0,
    
    gravity : 0.22,
    jump : 4.3,
    speed : 0,
    rotation : 0,
    
    draw: function(){
        let bird = this.animation[this.frame];
        
        ctx.save();
        ctx.translate(this.x, this.y);
        ctx.rotate(this.rotation);
        ctx.drawImage(sprites, bird.sX, bird.sY, this.w, this.h,- this.w/2, - this.h/2, this.w, this.h);
        
        ctx.restore();
    },
    
    flap: function(){
        this.speed = - this.jump;
    },
    
    update: function(){
        // IF THE GAME STATE IS "GET READY" STATE, THE BIRD MUST FLAP SLOWLY
        this.period = state.current == state.getReady ? 10 : 5;
        // INCREMENT THE FRAME BY 1, EACH PERIOD
        this.frame += frames%this.period == 0 ? 1 : 0;
        // FRAME GOES FROM 0 To 4, THEN AGAIN TO 0
        this.frame = this.frame%this.animation.length;
        
        if(state.current == state.getReady){
            this.y = 150; // RESET POSITION OF THE BIRD AFTER GAME OVER
            this.rotation = 0 * DEGREE;
        }else{
            this.speed += this.gravity;
            this.y += this.speed;
            
            if(this.y + this.h/2 >= cvs.height - fg.h){
                this.y = cvs.height - fg.h - this.h/2;
                if(state.current == state.game){
                    state.current = state.over;
                    DIE.play();
                }
            }
            
            // IF THE SPEED IS GREATER THAN THE JUMP MEANS THE BIRD IS FALLING DOWN
            if(this.speed >= this.jump){
                this.rotation = 90 * DEGREE;
                this.frame = 1;
            }else{
                this.rotation = -25 * DEGREE;
            }
        }
        
    },
    speedReset: function(){
        this.speed = 0;
    }
}

// GET READY MESSAGE
const getReady = {
    sX : 0,
    sY : 228,
    w : 173,
    h : 152,
    x : cvs.width/2 - 173/2,
    y : 80,
    
    draw: function(){
        if(state.current == state.getReady){
            ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
        }
    }
    
}

// GAME OVER MESSAGE
const gameOver = {
    sX : 175,
    sY : 228,
    w : 225,
    h : 202,
    x : cvs.width/2 - 225/2,
    y : 90,
    
    draw: function(){
        if(state.current == state.over){
            ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);   
        }
    }
    
}

// PIPES
const pipes = {
    position : [],
    
    top : {
        sX : 553,
        sY : 0
    },
    bottom:{
        sX : 502,
        sY : 0
    },
    
    w : 53,
    h : 400,
    gap : 100,
    passed : 0,
    maxYPos : -150,
    dx : 2,
    
    draw: function(){
        for(let i  = 0; i < this.position.length; i++){
            let p = this.position[i];
            
            let topYPos = p.y;
            let bottomYPos = p.y + this.h + this.gap;
                  
            // TOP PIPE
            ctx.drawImage(sprites, this.top.sX, this.top.sY, this.w, this.h, p.x, topYPos, this.w, this.h);  
            
            // BOTTOM PIPE
            ctx.drawImage(sprites, this.bottom.sX, this.bottom.sY, this.w, this.h, p.x, bottomYPos, this.w, this.h);           
        }
    },
    
    update: function(){
        if(state.current !== state.game) return;
        
        if(frames%100 == 0){
            this.position.push({
                x : cvs.width,
                y : this.maxYPos * ( Math.random() + 1)
            });
        }
        for(let i = 0; i < this.position.length; i++){
            let p = this.position[i];
            
            let bottomPipeYPos = p.y + this.h + this.gap;
            
            // COLLISION DETECTION
            // TOP PIPE
            if(bird.x + bird.radius > p.x && bird.x - bird.radius < p.x + this.w && bird.y + bird.radius > p.y && bird.y - bird.radius < p.y + this.h){
                state.current = state.over;
                HIT.play();
            }
            // BOTTOM PIPE
            if(bird.x + bird.radius > p.x && bird.x - bird.radius < p.x + this.w && bird.y + bird.radius > bottomPipeYPos && bird.y - bird.radius < bottomPipeYPos + this.h){
                state.current = state.over;
                HIT.play();
            }
            
            // MOVE THE PIPES TO THE LEFT
            p.x -= this.dx;
            
            // IF THE PIPES GO BEYOND CANVAS
            if(p.x + this.w <= 0){
                this.position.shift();
                score.value += 1;
                pipes.passed += 1;
                SCORE_S.play();

                if(playingGamemode == 1){
                    score.best1 = Math.max(score.value, score.best1);
                    localStorage.setItem("best1", score.best1);
                }
                else if(playingGamemode == 2){
                    score.best2 = Math.max(score.value, score.best2);
                    localStorage.setItem("best2", score.best2);
                }
                else if(playingGamemode == 3){
                    score.best3 = Math.max(score.value, score.best3);
                    localStorage.setItem("best3", score.best3);
                }  
            }

            // SHORTEN PIPE GAP (IN GAMEMODE 2)
            if(pipes.passed >= 2 && mayShortenGap == true && score.value <= 25){
                pipes.gap -= 5;
                pipes.passed = 0;
                shortenGap = true;
            }
        }
    },
    
    reset : function(){
        this.position = [];
        if(mayShortenGap){
            pipes.gap = 140;
        }
        else{
            pipes.gap = 100;
        }

        if(lowGravity){
            pipes.gap = 150;
        }
    }  
}

// SCORE
const score= {
    best1 : parseInt(localStorage.getItem("best1")) || 0,
    best2 : parseInt(localStorage.getItem("best2")) || 0,
    best3 : parseInt(localStorage.getItem("best3")) || 0,
    value : 0,
    
    draw : function(){
        ctx.fillStyle = "#FFF";
        ctx.strokeStyle = "#000";
        
        if(state.current == state.game){
            ctx.lineWidth = 2;
            ctx.font = "35px Teko";
            ctx.fillText(this.value, cvs.width/2, 50);
            ctx.strokeText(this.value, cvs.width/2, 50);
            
        }else if(state.current == state.over){
            // SCORE VALUE
            ctx.font = "25px Teko";
            ctx.fillText(this.value, 225, 186);
            ctx.strokeText(this.value, 225, 186);
            // BEST SCORE
            if(playingGamemode == 1){
                ctx.fillText(this.best1, 225, 228);
                ctx.strokeText(this.best1, 225, 228);
            }
            else if(playingGamemode == 2){
                ctx.fillText(this.best2, 225, 228);
                ctx.strokeText(this.best2, 225, 228);
            }
            else if(playingGamemode == 3){
                ctx.fillText(this.best3, 225, 228);
                ctx.strokeText(this.best3, 225, 228);
            }
        }
    },
    
    reset : function(){
        this.value = 0;
    }
}

// MEDALS
const medal = {
    sX : 360,
    sY : 158,
    x : 73,
    y : 176,
    w : 44,
    h : 44,

    draw: function(){
        if(state.current == state.over){
            // BRONZE MEDAL
            if(score.value >= 5 && score.value < 15){
                medal.sX = 360;
                medal.sY = 158;
                ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
            }
            // SILVER MEDAL
            else if(score.value >= 15 && score.value < 30){
                medal.sX = 360;
                medal.sY = 112;
                ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
            }
            // GOLD MEDAL
            else if(score.value >= 30 && score.value < 50){
                medal.sX = 312;
                medal.sY = 158;
                ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
            }
            // PLATINUM MEDAL
            else if(score.value >= 50){
                medal.sX = 312;
                medal.sY = 112;
                ctx.drawImage(sprites, this.sX, this.sY, this.w, this.h, this.x, this.y, this.w, this.h);
            }
        }
    }
}

// DRAW
function draw(){
    if(bird.jump == 4.6){
        ctx.fillStyle = "#008793";
    }
    else{
        ctx.fillStyle = "#70c5ce";
    }

    ctx.fillRect(0, 0, cvs.width, cvs.height);
    
    bg.draw();
    pipes.draw();
    fg.draw();
    bird.draw();
    getReady.draw();
    gameOver.draw();
    score.draw();
    medal.draw();
}

// UPDATE
function update(){
    bird.update();
    fg.update();
    pipes.update();
}

// LOOP
function loop(){
    update();
    draw();
    frames++;
    
    requestAnimationFrame(loop);
}
loop();