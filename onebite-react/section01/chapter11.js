// 함수선언
// JS에서는 함수 선언 아무데서나 해도 실행이 됨
// -> 호이스팅 기능 때문(끌어올린다는 뜻)
function greeting() {
  console.log("안녕하세요");
}

console.log("호출 전");
greeting(); // 이때 실행됨
console.log("호출 후");

function getArea(width, height) {
  function another() {
    console.log("another");
  }
  another();
  let area = width * height;

  return area;
}

let area1 = getArea(10, 20);
console.log(area1);
