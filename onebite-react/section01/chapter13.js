// 1. 콜백함수
function main(value) {
    console.log(value); //vaule()로도 됨= 함수이므로
}

function sub() {
    console.log("end"); // 2
}

main(sub);

main(() => {
    console.log("i am sub"); // 1
});


// 2. 콜백함수의 활용
function repeat(count, callback) {
    for (let i = 1; i <= count; i++) {
        callback(i);
    }
}

repeat(5, (i) => console.log(i));
repeat(5, (i) => console.log(i * 2)); // 중복코드 제거가능!