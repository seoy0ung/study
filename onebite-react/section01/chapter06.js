// 1. 묵시적 형 변환
// -> 자바스크립트 엔진이 알아서 형 변환 하는 것

let num = 10;
let str = "20";

const result = num + str; // num이 str 타입으로 묵시적 형변환
console.log(result);

// 2. 명시적 형 변환
// -> 프로그래머 내장함수 등을 이용해서 직접 형 변환을 명시
// -> 문자열 -> 숫자
let str1 = "10";
let strToNum1 = Number(str1); // 내장 함수 사용해서 변환
console.log(10 + strToNum1);

let str2 = "10개";
let strToNum2 = parseInt(str2); // 숫자값이 아닌 함수 내부 인자도 모두 숫자로 변환

// -> 숫자 -> 문자열
let num1 = 20;
let numToStr1 = String(num1);

console.log(numToStr1 + "입니다");
