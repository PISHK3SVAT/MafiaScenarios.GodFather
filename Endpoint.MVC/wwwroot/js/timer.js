//var countdownNumberEl = document.getElementById('countdown-number');
//var countdown = 40;

//countdownNumberEl.textContent = countdown;

//setInterval(function () {
//    countdown = --countdown <= 0 ? 10 : countdown;

//    countdownNumberEl.textContent = countdown;
//}, 1000);
let circleAnimation;

function startCountDown(containerId) {
    circleAnimation.play();

    const container = document.getElementById(containerId);
    const span = container.lastChild;
    let value = span.innerHTML;
    let countDown = value;
    var localIntervalId = setInterval(() => {
        countDown--;
        if (countDown == 0)
            clearInterval(localIntervalId);

        span.innerHTML = countDown;
    }, 1000);
    return localIntervalId;
}
function stopCountDown(intervalId) {
    circleAnimation.pause();
    clearInterval(intervalId);
}
function createCountDown(containerId,radius,value,strokeWidth='10',strokeColor='red',strokeBgColor='black') {
    const container = document.getElementById(containerId);
    const ns = 'http://www.w3.org/2000/svg';

    //container style
    container.style.position = 'relative';
    container.style.display = 'inline-block';
    container.style.borderRadius = '50%';
    container.style.boxShadow = `inset 0px 0px 0px ${strokeWidth}px ${strokeBgColor}`;
    //svg
    const svg = document.createElementNS(ns,'svg');
    svg.setAttribute('width', radius * 2 + parseInt(strokeWidth));
    svg.setAttribute('height', radius * 2 + parseInt(strokeWidth));
    //style
    svg.style.transform = 'rotateY(-180deg) rotateZ(-90deg)';

    //circle
    const circle = document.createElementNS(ns, 'circle');
    circle.setAttribute('r', radius);
    circle.setAttribute('cx', radius + (strokeWidth / 2));
    circle.setAttribute('cy', radius + (strokeWidth / 2));
    circle.setAttribute('fill', 'none');
    circle.setAttribute('stroke', strokeColor);
    circle.setAttribute('stroke-width', strokeWidth);
    circle.setAttribute('stroke-linecap', 'round');
    circle.setAttribute('stroke-dashoffset', '0');
    circle.setAttribute('stroke-dasharray', radius * 6 + parseInt(strokeWidth));

    //span
    const span = document.createElement('span');
    span.innerHTML = value;
    //style
    span.style.position = 'absolute';
    span.style.top = '50%';
    span.style.left = '50%';
    span.style.transform = 'translate(-50%,-50%)';
    span.style.fontSize = '2rem';

    svg.appendChild(circle);
    container.appendChild(svg);
    container.appendChild(span);

    //circle animation
    circleAnimation = circle.animate(
    {
        strokeDashoffset: [0, radius*6]
    },
    {
        duration: value*1000,
        iterations: '1',
        direction: 'normal',
        easing: 'linear',

        });
    circleAnimation.pause();
    //let countDown = value;
    //setInterval(() => {
    //    countDown = --countDown <= 0 ? value : countDown;

    //    span.innerHTML = countDown;
    //},1000)
}