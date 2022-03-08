filterSelection("all") // Execute the function and show all columns
function filterSelection(c) {
  var x, i;
  x = document.getElementsByClassName("column");
  if (c == "all") c = "";
  // Add the "show" class (display:block) to the filtered elements, and remove the "show" class from the elements that are not selected
  for (i = 0; i < x.length; i++) {
    IconShow(x[i], "show");
    if (x[i].className.indexOf(c) > -1) AddClass(x[i], "show");
  }
}

// Show filtered elements
function AddClass(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    if (arr1.indexOf(arr2[i]) == -1) {
      element.className += " " + arr2[i];
    }
  }
}

// Hide elements that are not selected
function IconShow(element, name) {
  var i, arr1, arr2;
  arr1 = element.className.split(" ");
  arr2 = name.split(" ");
  for (i = 0; i < arr2.length; i++) {
    while (arr1.indexOf(arr2[i]) > -1) {
      arr1.splice(arr1.indexOf(arr2[i]), 1);
    }
  }
  element.className = arr1.join(" ");
}

// Add active class to the current button (highlight it)
var btnContainer = document.getElementById("myBtnContainer");
var btns = btnContainer.getElementsByClassName("btn");
for (var i = 0; i < btns.length; i++) {
  btns[i].addEventListener("click", function(){
    var current = document.getElementsByClassName("active");
    current[0].className = current[0].className.replace(" active", "");
    this.className += " active";
  });
}

//Clickable Images
const containers = document.getElementsByClassName("container");

[].forEach.call(containers, function (item) {
    item.addEventListener('mouseover', hoverVideo, false);
    item.addEventListener('mouseout', hideVideo, false);
});

function hoverVideo(e) {
    this.getElementsByClassName("preview")[0].play();
}
function hideVideo(e) {
    this.getElementsByClassName("preview")[0].pause();
}

for (var i = 0; i < containers.length; i++) {
    var a = containers[i];
    var buttonCount = a.getElementsByClassName('button').length;

    switch (buttonCount) {
        case 1:
            a.getElementsByClassName('button')[0].style.marginLeft = '25%';
            break;

        case 2:
            a.getElementsByClassName('button')[0].style.marginLeft = '10%';
            a.getElementsByClassName('button')[1].style.marginLeft = '40%';
            break;

        case 3:
            a.getElementsByClassName('button')[2].style.marginLeft = '0%';
            a.getElementsByClassName('button')[1].style.marginLeft = '50%';
            a.getElementsByClassName('button')[0].style.marginLeft = '25%';
            break;
    }
}