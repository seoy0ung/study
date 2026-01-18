// 1. 상수 객체
const animal = {
    type: "고양이",
    name: "나비",
    color: "black",
};

animal.age = 2; // 추가
animal.name = "두리"; // 수정
delete animal.color; // 삭제

// 가능한 이유 = 상수는 새로운 값을 할당하는게 안돼서 저장되어있는 객체 값의
// 프로퍼티를 추가 수정 삭제하는건 얼마든지 가능하다

// 2. 메서드
// -> 값이 함수인 프로퍼티를 말함
const person = {
    name: "홍길동",
    // 메서드
    sayHi() {
        console.log("안녕!");
    },
};

person.sayHi(); // 메서드 호출
person["sayHi"](); // 괄호 표기법으로도 호출 가능

