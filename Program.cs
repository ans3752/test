using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static int[] Select(int[] arr, Func<int, bool> func)
        {
            int count = 0;
            foreach (var x in arr)
                if (func(x)) count++;

            int[] ret = new int[count];

            count = 0;
            foreach (var x in arr)
                if (func(x))
                    ret[count++] = x;

            return ret;
        }


        static void Main(string[] args)
        {

        }
    }
}

#region C# 표준 라이브러리에 대한 기본사항

// 1. 편의성을 향상시키는 함수들
/*
.NET Framework에는 상당히 많은 메서드(함수)가 준비되어 있다.
사용자가 직접 추가할 필요없이 있는 그대로 사용할 수 있는 함수군을 표준 라이브러리라고 한다.

.NET Framework 표준 라이브러리는 매우 방대하기에
이에 대한 내용을 모두 설명하는 것은 사실상 불가능에 가깝다.
*/

// 2. 함수와 메서드
/*

C#에서는 함수를 메서드(Method)라고 부른다.

나중에 설명할 클래스의 한 기능으로 제공되고 있지만,
의미를 따진다고 하면 함수나 메서드나 거의 똑같은 물건이다.

적어도 C# 프로그래밍에서는 이것을 굳이 구분한다고 해서
의미가 있는 것은 아니니 자신이 편한 대로 불러도 상관없다.

*/

// 3. 인스턴스 메서드와 정적 메서드
/*
C# 메서드는 크게 2가지로 나뉜다.

정적 메서드는 '데이터타입.메서드명()' 의 형식으로 호출하는 메서드이다.
인스턴스 메서드는 '변수명.메서드명()' 의 형식으로 호출하는 메서드이다.

=====

string str = "I have a pen.";

// 정적 메서드
// 문자열이 null 또는 공백일 때 bool형 데이터를 반환
string.IsNullOrEmpty(str);

// 인스턴스 메서드
// 변수에 저장된 문자열을 모두 대문자로 변환
str.ToUpper();

=====

정적 메서드는 조작 대상으로써 취급하는 데이터를 인수로 지정한다.
인스턴스 메서드는 조작 대상으로써 취급하는 데이터를 도트 연산자의 좌측에 지정한다.

또한, 정적 메서드는 정적 함수 또는 static 메서드라고도 부른다.

*/

// 4. 인스턴스 메서드의 주의사항
/*

인스턴스 메서드는 변수의 값이 null인 상태에서는 호출이 불가능하다.

해당 메서드를 호출하는 시점에서 바로 에러를 출력하며,
정적 메서드가 null을 인수로 전달하여도 실행이 되긴 하나
무조건 괜찮다고 보장할 수는 없다.

=====

string str = null;

// 정적 메서드는 가능
string.IsNullOrEmpty(str);

// 인스턴스 메서드는 불가능
str.ToUpper();

=====

*/

// 5. 프로퍼티 (Property)
/*

인스턴스 메서드와 비슷한 녀석으로 프로퍼티라는 것이 존재한다.

프로퍼티는 변수가 포함하고 있는 세부 정보라고 봐도 된다.
메서드와는 또 다른 개념인 프로퍼티는 인수가 존재하지 않으며,
소괄호조차 사용하지 않는다.

=====

string str = "I have a pen.";

// 문자열의 길이를 반환하는 Length 프로퍼티
int length = str.Length;

=====

*/

// 6. 메서드 체인
/*
하나의 데이터에 대해 몇 가지 메서드를 적용하여 가공해야 하는 경우가 있다.
이 때는 당연하다면 당연하지만 필요한 메서드를 순서대로 호출하여 처리한다.

=====

string str = "I have a red pen.";

// Replace 메서드
string strResult = str.Replace("red", "");

// ToUpper 메서드
strResult = strResult.ToUpper();

=====

기존의 방식은 소스 코드가 아래로 길어지기 때문에
만약 자신이 정의한 내용을 기반으로 써내려갈 때 자칫 잘못하면
가독성이 저하되는 현상을 초래할 수 있다.

이를 조금이라도 최소화하고자 사용하려는 메서드를 연이어 호출하는 방법이 있다.

=====

// Replace → ToUpper 순서로 메서드 호출
string str2 = str.Replace("red", "").ToUpper();

=====

이러한 방식을 메서드 체인이라고 한다.

주의할 점은 두 번째 이후의 사용 가능한 메서드는 인스턴스 메서드로 한정한다.
그리고 반환값이 없는 메서드(void)의 뒤에는 메서드 체인을 사용할 수 없다.
*/

#endregion

#region 배열의 메서드

// 1) Array 클래스
/*
배열은 복수의 데이터를 한꺼번에 다룰 수 있는 기능이다.
단순히 여러 개의 변수를 하나로 묶어두는 것 뿐만이 아니라,
여러가지 편리한 기능을 제공하고 있다.
여기에서는 배열의 조작 방법으로 끝나지 않고 자주 사용하는 메서드(함수)를 소개한다.

배열을 조작하기 위한 메서드들은 Array 라는 클래스에 존재한다.
여기서 클래스라는 것은 어떠한 기능을 실현하기 위해 만들어둔
데이터군을 한 곳에 모아둔 것이라고 보면 편하다.
*/

// 2) 배열의 기본
/*
앞서 배운 배열에서 설명한 기본 내용을 간단히 정리하였다.

=====

// 배열의 선언 (사이즈는 3)
int[] nums1 = new int[3];

// 선언과 동시에 초기화
int[] nums2 = new int[] { 1, 2, 3 };

// 선언과 동시에 초기화 (생략형)
int[] nums3 = { 1, 2, 3 };

// 각 요소에 접근
int num = nums2[0]; //1

// 요소 갯수 획득
int length = nums2.Length; //3

=====
*/

#region 3) Array.Clear (요소의 클리어)

// 1. 기본 정보
/*
배열의 요소를 모두 초기값으로 되돌리는 데에 사용하는 메서드이다.

=====

int[] nums = new int[] { 1, 2, 3, 4, 5 };

// 배열을 모두 클리어
// (첫 번째 요소부터 배열의 크기만큼 클리어)
Array.Clear(nums, 0, nums.Length);

foreach (var n in nums)
    Console.Write("{0}, ", n);

Console.WriteLine();
nums = new int[] { 1, 2, 3, 4, 5 };

// 두 번째 요소부터 2개 분량만큼만 클리어
Array.Clear(nums, 1, 2);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====

첫 번째 인수에 클리어하고 싶은 배열을 지정한다.
두 번째 인수에 클리어 작업을 시작할 요소 번호를 지정한다.
세 번째 인수에 클리어할 범위를 지정한다.

만약 배열 전체를 클리어하고 싶다면 제2인수에 0을,
그리고 제3인수에 해당 배열의 Length를 전달하면 된다.
*/

// 2. 다차원 배열의 경우
/*
다차원 배열에 대해 Array.Clear 메서드를 적용할 수 있다.
클리어하는 범위는 다차원 배열을 1차원 배열로써 간주하여 지정한다.

=====

int[,] nums = new int[,] {
    { 0, 1, 2 },
    { 3, 4, 5 },
    { 6, 7, 8 },
};

// 모두 클리어
Array.Clear(nums, 0, nums.Length);

nums = new int[,] {
    { 0, 1, 2 },
    { 3, 4, 5 },
    { 6, 7, 8 },
};

// 3번째부터 5개 분량만큼만 초기화
Array.Clear(nums, 2, 5);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====
*/

// 3. 가변 배열의 경우
/*
가변 배열은 배열의 배열이므로 그대로 Array.Clear 메서드를 적용하면
첫 번째 차원(선두 요소)만이 초기화되고, 두 번째 차원은 초기화되지 않는다.
(배열은 참조 타입이므로 여기에선 null이 설정됨)

=====

int[][] nums = new int[][] {
    new int[] { 0, 1, 2 },
    new int[] { 3, 4 },
    new int[] { 5, 6, 7, 8 },
};

// 첫 번째 차원을 모두 클리어
Array.Clear(nums, 0, nums.Length);

=====

가변 배열을 사용할 때 단순한 Clear의 사용은 첫 번째 차원만을 초기화한다.

두 번째 차원 이후의 요소는 그대로 존재하지만
접근할 수단 자체가 사라지는 문제가 발생한다.

때문에 가변 배열의 요소를 모두 초기화하고 싶은 경우에는
뒷쪽에 위치한 배열부터 역순으로 초기화하는 것을 권장한다.

=====

int[][] nums = new int[][] {
    new int[] { 0, 1, 2 },
    new int[] { 3, 4 },
    new int[] { 5, 6, 7, 8 },
};

// 모든 두 번째 차원 요소를 클리어
for(int i = 0; i < nums.Length; i++)
{
    Array.Clear(nums[i], 0, nums[i].Length);
}

// 모든 첫 번째 차원의 요소를 클리어
Array.Clear(nums, 0, nums.Length);

=====

접근할 수단이 사라진 변수는 자동으로 삭제되므로
첫 번째 차원만 클리어했다고 해서 시스템에 큰 문제는 되지 않는다.

*/

#endregion

#region 4) Array.Resize (요소 수의 변경)

// 1. 기본 정보
/*
배열의 요소 갯수, 사이즈를 변경하고 싶은 경우 Array.Resize 메서드를 사용한다.

=====

int[] nums = new int[] { 1, 2, 3 };

// 사이즈를 5로 변경
Array.Resize(ref nums, 5);

foreach (var n in nums)
    Console.Write("{0}, ", n);

Console.WriteLine();


// 사이즈를 2로 변경
Array.Resize(ref nums, 2);

foreach (var n in nums)
    Console.Write("{0}, ", n);
=====

첫 번째 인수에 요소 수를 변경하고 싶은 배열을 지정한다.
이 때 ref 키워드를 지정해야 한다.
그리고 두 번째 인수에 사이즈 변경 후의 요소 갯수를 지정한다.

기본보다 요소 갯수를 늘렸을 경우,
새로운 요소에는 기본값이 자동으로 설정된다.

만약 반대로 하였다면 해당 데이터는 자동으로 소멸한다.
*/

// 2. 다차원 배열의 경우
/*
다차원 배열에는 사용할 수 없다. (에러 출력)
*/

// 3. 가변 배열의 경우
/*
가변 배열에 해당 메서드를 사용하면 첫 번째 차원의 사이즈만 변경할 수 있다.
배열은 참조 타입이라 요소 갯수를 증가시켰을 경우에는
새로이 추가된 요소에 기본값인 null을 삽입한다.

두 번째 차원의 요소 수를 변경하는 경우에는
보관되어 있던 각각의 배열에 접근한 상태에서 Array.Resize 를 사용한다.
*/

#endregion

#region 5) Array.CopyTo (배열의 복사)

// 1. 기본 정보
/*
어떠한 배열의 모든 것을 또 다른 배열의
특정 요소 위치에 복사할 때 사용하는 메서드이다.

=====

int[] nums1 = new int[] { 1, 2, 3 };
int[] nums2 = new int[] { 4, 5, 6, 7 };

// nums1 전체를 num2의 두 번째 요소 위치부터 복사
nums1.CopyTo(nums2, 1);

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====

CopyTo 메서드의 기본 사용 방법은
복사하고 싶은 배열을 입력한 뒤에 .(도트)를 입력하고
CopyTo 메서드를 호출한다.

첫 번째 인수에 값을 복사할 배열을 지정한다.
두 번째 인수에 값이 복사될 배열의 내부 위치를 지정한다.
(index를 사용)

'index + 값을 복사할 배열의 사이즈' 보다 값이 복사될 배열의
사이즈가 적은 경우에는 에러를 출력한다.
또한, index에 마이너스 값을 지정해도 에러를 출력한다.

CopyTo 메서드는 값을 복사할 배열의 데이터를
값이 복사될 배열에 복사하는 역할을 수행한다.

값이 복사될 배열의 몇 번째 요소에서부터
데이터를 삽입할 것인가를 지정할 수 있지만,

사용처가 콕 집어 이야기하기에는 어중간하기 때문에
이것보다는 뒤이어 설명할 Array.Copy 를 권장한다.
*/

// 2. 다차원 배열의 경우
/*
못 쓴다.
다차원 배열의 복사는 Array.Copy 메서드를 사용한다.
*/

// 3. 가변 배열의 경우
/*
가변 배열에 CopyTo 메서드를 사용하면
첫 번째 차원의 요소만 복사를 수행한다.
단, 값이 삽입되는 배열도 가변 배열이어야만 한다.

데이터가 보관된 배열의 요소를 복사하는 경우에는
해당 배열에 접근이 완료된 상태에서 CopyTo를 사용한다.

=====

int[][] nums1 = new int[][]
{
    new int[] {0,1,2 },
    new int[] {3,4 },
    new int[] { 5,6,7,8}
};

int[] nums2 = new int[4];

// nums1의 세 번째 요소를 num2에 그대로 복사
nums1[2].CopyTo(nums2, 0);

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====
*/

#endregion

#region 6) Array.Copy (배열의 복사)

// 1. 기본 정보
/*
배열 하나의 요소 범위를 임의로 설정한 뒤에 이를 다른 배열에 복사하는 메서드이다.

=====

int[] nums1 = new int[] { 1, 2, 3 };
int[] nums2 = new int[] { 4, 5, 6, 7 };

// nums1의 처음부터 시작하여 2개분의 요소를 nums2의 처음에 복사
Array.Copy(nums1, nums2, 2);

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====

첫 번째 인수에는 복사할 배열, 두 번째 인수에는 값이 저장될 배열을 지정한다.
그리고 세 번째 인수에는 복사할 요소의 갯수를 지정한다.

모든 요소를 복사하는 경우에는 제3인수에 배열 자체의 크기를 지정하면 끝이지만,
지정한 값이 값을 복사할 배열 또는 값이 복사될 배열의 크기보다 크면 에러를 출력한다.

Array.Copy는 값을 복사할 배열의 복사 시작 번호와 길이,
값이 복사될 배열의 복사 시작 번호를 지정하여 복사하는 것도 가능하다.

인수가 그만큼 많이 들어간다는 것이 흠이지만,
그만큼 유연한 대처가 가능하다는 장점이 있다.

=====

int[] nums1 = new int[] { 1, 2, 3 };
int[] nums2 = new int[] { 4, 5, 6, 7 };

// nums1의 처음부터 시작하여 2개분의 요소를 nums2의 처음 위치에 붙여넣기
// nums1의 2~3번째 요소를 nums2의 2번째 요소 위치에 복사
Array.Copy(nums1, 1, nums2, 1, 2);

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====

*/

// 2. 다차원 배열의 경우
/*
Array.Copy는 다차원 배열의 복사도 가능하다.
단, 데이터를 전달하는 과정에서 양측의 데이터 타입이 동일해야하며,
(주는 쪽이 2차 배열이면 받는 쪽도 2차 배열)
값을 복사할 배열의 요소 갯수만 충족되어 있다면 각 차원의 요소 갯수는 비교적 자유롭다.

복사 범위는 다차원 배열을 1차원 배열로써 간주하고 지정해야 한다.

=====

int[,] nums = new int[3, 4] {
    { 1, 2, 3, 4 },
    { 5, 6, 7, 8 },
    { 9, 10, 11, 12 }
};

int[,] nums2 = new int[2, 6];

// 값이 복사될 배열이 2차 배열이고 요소 갯수가 10 이상이면 복사 가능
Array.Copy(nums, nums2, 10);

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====
*/

// 3. 가변 배열의 경우
/*

가변 배열에 Array.Copy 메서드를 적용하면 첫 번째 차원의 요소(배열)의 복사가 가능하다.
하지만 값이 복사될 배열도 가변 배열 형태이어야만 한다.

=====

int[][] nums1 = new int[][] {
    new int[] { 0, 1, 2 },
    new int[] { 3, 4 },
    new int[] { 5, 6, 7, 8 },
};

int[] nums2 = new int[4];

//nums1에 존재하는 0번째 배열의 첫 번째 요소부터 3개분을 num2에 복사
Array.Copy(nums1[0], nums2, 3);

foreach(var n in nums2)
    Console.Write("{0}, ", n);

=====
*/

#endregion

#region 7) Array.Clone (배열의 복제)

// 1. 기본 정보
/*
배열을 복제하기 위해서는 Array.Clone 메서드를 사용한다.
반환값이 object형이기 때문에 캐스트를 사용해줘야 원활한 처리가 가능하다.

=====

int[] nums1 = new int[] { 1, 2, 3 };
int[] nums2;

// nums1의 복제품을 만들어 nums2에 대입 (as 연산자)
nums2 = nums1.Clone() as int[];

// nums1의 복제품을 만들어 nums2에 대입 (형변환 연산자)
// nums2 = (int[])nums1.Clone();

foreach (var n in nums2)
    Console.Write("{0}, ", n);

=====

*/

// 2. 다차원 배열, 가변 배열의 경우
/*
Array.Clone 메서드는 다차원 배열과 가변 배열에도 적용 가능하다.

사용 방법은 1차원 배열과 똑같이 복제하는 배열의
데이터 타입으로 캐스트를 진행하고 전달해주면 된다.
*/

// 3. 복사 메서드의 주의사항
/*
배열의 복사 메서드(CopyTo, Clone 등)은 기본적으로 얕은 복사의 개념을 기반으로 한다.
값 타입 배열의 복사는 아무런 문제 없지 처리하지만,
참조 타입의 배열 같은 경우에는 주소를 복사하니 주의할 것.

=====

int[][] nums1 = new int[][] {
    new int[] { 1, 2, 3 },
    new int[] { 4, 5, 6 }
};

int[][] nums2 = nums1.Clone() as int[][];

// 복제 후에 복제한 대상의 값을 바꿔쓴다
nums1[0][0] = 9;

foreach (var x in nums1)
    foreach (var y in x)
        Console.Write("{0}, ", y);

Console.WriteLine();

foreach (var x in nums1)
    foreach (var y in x)
        Console.Write("{0}, ", y);

=====

가변 배열에는 배열 타입으로 요소가 존재하다 보니 참조 타입으로 취급한다.
따라서 Array.Clone 메서드를 사용하면 얕은 복사를 수행한다.

상기 샘플 코드에는 배열의 복제 후에
복제 대상이 되었던 배열의 요소의 데이터를 바꿔쓰고 있다.

얕은 복사를 수행하니 복제한 배열의 요소도 바뀐 것을 확인할 수 있다.
*/

#endregion

#region 8) Array.Sort (배열의 정렬)

// 1. 기본 정보
/*
배열의 요소를 오름차순으로 정렬하기 위해 Array.Sort 메서드를 사용한다.
내림차순으로 정렬하기 위해서는 Array.Reverse 메서드와 병행한다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 정렬
Array.Sort(nums);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====

아래 코드와 같이 정렬 시작 위치와 요소 갯수를 지정하여
특정 범위만 정렬이 되게끔 할 수도 있다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 두 번째 요소부터 3개 분량만큼만 정렬한다
Array.Sort(nums, 1, 3);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====

*/

// 2. 메서드를 사용한 정렬
/*
Array.Sort 메서드는 정렬용 메서드를 추가로 사용하여 순서를 임의변경할 수 있다.

예를 들어 string형의 정렬은 일반적으로 ABC순으로 하지만,
아래의 코드는 문자수가 적은 순으로, 그리고 똑같은 문자 수의 경우에는 ABC순으로
라는 규칙을 적용하여 재정렬을 수행한다.

=====

// Sort 메서드용의 비교 메서드
// 음수를 반환하면 x가 앞에 온다
// 정수를 반환하면 y가 앞에 온다
// 0을 반환하면 양쪽은 똑같음
static int CompareString(string x, string y)
{
    // null 체크
    if (x == null && y == null)
        return 0;
    if (x == null)
        return -1;
    if (y == null)
        return 1;

    if (x.Length < y.Length)
        return -1;
    if (x.Length > y.Length)
        return 1;
    // 문자 수가 똑같은 경우에는 그대로 진행
    return string.Compare(x, y);
}

static void Main(string[] args)
{
    var strs = new string[]
    { "Tom", "James", "Michael", "Chris", "Boby" };

    Array.Sort(strs);

    foreach (var s in strs)
        Console.Write("{0}, ", s);

    Console.WriteLine();

    // 비교 메서드를 사용하고 재정렬
    Array.Sort(strs, CompareString);

    foreach (var s in strs)
        Console.Write("{0}, ", s);

    Console.ReadLine();
}

=====
*/

// 3. 다차원 배열의 경우
/*
불가능하다.
*/

// 4. 가변 배열의 경우
/*
정렬하기 위한 메서드를 직접 정의해야 한다.

가변 배열은 배열의 배열이기 때문에 배열끼리를 비교하게 되는데,
이것은 숫자와 문자열처럼 무언가를 기준으로 비교하는지 명확하지 않기 때문.
그래서 자기가 직접 비교를 하기 위해 규칙을 정하는 것이다.

아래의 코드는

    1. 2개의 배열을 선두의 요소부터 비교한다.
    2. 다른 값이 검출되면 값이 작은 쪽을 앞에 둔다.
    3. 2에서 순서가 결정되지 않았을 경우에는 양 배열의 요소 갯수를 비교하며,
       요소 갯수가 적은 쪽을 앞에 둔다.
    4. 요소 갯수도 동일한 경우에는 양 배열을 모두 똑같은 것이라 취급한다. (정렬 불필요)

라는 규칙으로 비교한 예시이다.
구체적인 처리는 주석을 참조할 것.

=====

// Sort 메서드용의 배열 길이 비교 메서드
// 음수를 반환하면 x가 앞에 온다
// 정수를 반환하면 y가 앞에 온다
// 0을 반환하면 양쪽은 똑같음
static int CompareArray(int[] x, int[] y)
{
    // 요소 갯수가 적은 쪽을 받아온다
    int min = x.Length < y.Length ? x.Length : y.Length;

    // 참고로 이런 메서드도 사용 가능
    //int min = Math.Min(x.Length, y.Length);

    // 똑같은 요소 번호끼리 비교
    // 다른 값이 출현한 경우에는 작은 쪽을 앞에 둔다
    for (int i = 0; i < min; i++)
    {
        if (x[i] < y[i])
            return -1;
        else if (x[i] > y[i])
            return 1;
    }

    //↑의 처리에서 값이 모두 동일한 경우에는 요소 수가 적은 쪽을 앞에 둔다
    if (x.Length < y.Length)
        return -1;
    else if (x.Length > y.Length)
        return 1;
    else // 요소 수까지 똑같으면 양 배열은 동일한 것으로 간주
        return 0;
}

static void Main(string[] args)
{
    int[][] nums = new int[][] {
        new int[] { 0, 1 },
        new int[] { 0, 2 },
        new int[] { 1, 2 },
        new int[] { 0, 1, 2 },
        new int[] { 0, 2, 3 },
        new int[] { 1, 2, 3 },
        new int[] { 0, 1, 2, 3 }
    };

    // 전용 메서드를 사용하여 정렬
    Array.Sort(nums, CompareArray);

    foreach (var arr in nums)
    {
        foreach (var n in arr)
            Console.Write("{0}, ", n);
        Console.WriteLine();
    }
    Console.ReadLine();
}

=====

첫 번째 인수에는 정렬하고 싶은 배열을 지정한다.
두 번째 인수에 직접 정의한 정렬용 메서드를 지정한다.

두 번째 인수에 정렬용 메서드를 지정할 때에는
일반적인 메서드의 호출과 다르게 인수를 적지도 않고 괄호도 생략한다.

이것은 Array.Sort 메서드에 비교용 메서드로써 어떤 것을 사용할지
명시할 뿐이기 때문에 실제 메서드 호출에는 Array.Sort 메서드가 알아서 해준다.

메서드의 매개변수도 Array.Sort 가 자동 설정해준다.
*/

#endregion

#region 9) Array.Reverse (배열의 반전)

// 1. 기본 정보
/*
배열의 요소 순서를 반전시키기 위해 Array.Reverse 메서드를 사용한다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 순서를 반전
Array.Reverse(nums);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====

Array.Sort 메서드와 비슷하게, 범위를 지정하여 일부만 반전하는 것도 가능하다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 두 번째 요소부터 3개 분량만큼만 순서 반전
Array.Reverse(nums, 1, 3);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====
*/

// 2. 내림차순 정렬
/*
모든 요소를 내림차순으로 정렬하기 위해서는 Array.Sort 메서드를
1차 적용하고 나서 Reverse 메서드를 사용해야 한다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 오름차순 정렬
Array.Sort(nums);

// 순서 반전
Array.Reverse(nums);

foreach (var n in nums)
    Console.Write("{0}, ", n);

=====
*/

// 3. 다차원 배열의 경우
/*
불가능하다.
*/

// 4. 가변 배열의 경우
/*
선두 요소(첫 번째 배열)의 요소만 반전을 수행한다.
내부에 보관된 배열의 요소를 모두 반전하기 위해서는
각 배열에 접근한 뒤에 Reverse 메서드를 사용해야 한다.
*/

#endregion

#region 10) Contains (요소의 존재 여부 판단)

// 1. 기본 정보
/*
배열의 요소에 특정 값이 존재하는지를 판단해야 할 경우에는 Contains 메서드를 사용한다.
이 메서드는 인스턴스 메서드이다.

엄밀히 말해서 Contains 메서드는 배열에 속한 메서드는 아니지만,
편리한 기능을 가지고 있어 소개한다.
Contains 메서드를 사용하기 위해서는 소스 코드 맨 처음에 using System.Linq;를 입력한다.

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

int num1 = 12;
int num2 = 13;

Console.Write("배열 nums 안에「{0}」는 존재", num1);
if (nums.Contains(num1))
    Console.WriteLine("합니다.");
else
    Console.WriteLine("하지 않습니다.");

Console.Write("배열 nums 안에「{0}」는 존재", num2);
if (nums.Contains(num2))
    Console.WriteLine("합니다.");
else
    Console.WriteLine("존재하지 않습니다.");

=====

인수로 지정한 값이 배열 내부에 하나라도 존재하면 true를 반환한다.
하지만 발견하지 못했을 경우에는 false를 반환한다.

요소가 배열 내부의 어느 위치에라도 존재한다는 것을 알고 싶다면
뒤에 소개할 Array.IndexOf, Array.LastIndexOf 같은 메서드를 사용한다.
*/

// 2. 다차원 배열, 가변 배열의 경우
/*
불가능하다.
*/

#endregion

#region 11) Array.IndexOf (요소의 검색)

// 1. 기본 정보
/*
배열에서 요소를 검색하기 위해 사용하는 메서드이다.

=====

int[] nums = new int[] { 5, 12, 16 };

// 12를 검색한다
int index1 = Array.IndexOf(nums, 12);

// 13을 검색한다.
int index2 = Array.IndexOf(nums, 13);

Console.WriteLine(index1);
Console.WriteLine(index2);

=====

첫 번째 인수에는 검색 대상으로 할 배열을 지정한다.
두 번째 인수는 검색하고 싶은 값을 입력한다.

해당 요소를 발견한 경우에는 인덱스를 반환한다.
만약 발견하지 못했다면 -1 을 반환한다.

Array.IndexOf 메서드는 배열의 처음부터 검사하며,
최초로 발견한 요소의 인덱스를 반환한다.

물론 아래와 같은 처리도 가능하다.

=====

int[] nums = new int[] { 5, 12, 16, 3, 7, 16 };

// 요소 목록에서 16을 검색
int index1 = Array.IndexOf(nums, 16);

// 배열의 네 번째 요소가 위치한 곳부터 16을 검색한다
// 검색 대상: 3, 7, 16
int index2 = Array.IndexOf(nums, 16, 3);

// 네 번재 요소에서부터 요소 2개분만큼의 범위 내에서 16을 검색
//검색 대상: 3, 7
int index3 = Array.IndexOf(nums, 16, 3, 2);

Console.WriteLine(index1);
Console.WriteLine(index2);
Console.WriteLine(index3);

=====

또한, 해당하는 모든 요소를 출력하기 위해서는 아래와 같이 작성한다.
만약 단순히 요소가 존재하는지에 대한 결과를 받고 싶다면
Contains 메서드를 사용하는 편이 좋다.

=====

int[] nums = new int[] { 0, 12, 16, 0, 7, 0, 3 };
int index = -1;

// 0이 나오는 위치를 모두 표시
while(true)
{
    // 이전에 발견한 요소에서부터 다음을 검색의 범주에 넣기 위해 1을 가산한다
    index = Array.IndexOf(nums, 0, index + 1);
    if (index >= 0)
    {
        Console.WriteLine(index);
        continue;
    }
    break;
}

=====

*/

// 2. 다차원 배열, 가변 배열의 경우
/*
불가능하다. 
*/

#endregion

#region 12) Array.LastIndexOf (요소의 검색2)

// 1. 기본 정보
/*
배열의 처음이 아닌 배열의 끝에서부터 검색하는 메서드이다.
검색의 시작 위치에 마지막이라는 것을 제외하면 Array.IndexOf와 동일하다.

반환값은 뒤에서부터 세지 않고 인덱스 자체를 반환하니 주의할 것.

=====

int[] nums = new int[] { 0, 12, 16, 0, 7, 0, 3 };

// 전방검색
int index = Array.IndexOf(nums, 0);

// 후방검색
int Lindex = Array.LastIndexOf(nums, 0);

Console.WriteLine(index);
Console.WriteLine(Lindex);

=====
*/

// 2. 다차원 배열, 가변 배열의 경우
/*
불가능하다.
*/

#endregion

#region 13) Array.BinarySearch (요소의 이분검색)

// 1. 기본 정보
/*
요소를 검색할 때 BinarySearch 메서드를 사용하는 방법도 있다.

Array.IndexOf 메서드는 요소를 처음부터 순서대로 검색하지만,
Array.BinaryScarch 메서드는 이분검색이라는 방법으로 검색을 진행한다.

이 검색 방법은 Array.IndexOf 메서드보다 더욱 빠르게 검색할 수 있다.
그러나 요소 정렬 순서가 반드시 오름차순이어야만 하는 단점이 있다.

따라서 Array.BinarySearch 메서드를 사용하기 전에 Array.Sort를 적용해야 한다.
(오름차순으로 정렬된 것을 확인한 상태라면 안 써도 괜찮음)

=====

int[] nums = new int[] { 12, 16, 0, 7, 5 };

// 오름차순으로 재정렬
Array.Sort(nums);

// 12를 검색
int index = Array.BinarySearch(nums, 12);

foreach (var n in nums)
    Console.Write("{0}, ", n);

Console.WriteLine("\n「12」는{0}번째", index + 1);

=====

Array.BinaryScarch 는 검색할 요소에 IComparable 인터페이스가
적용되어 있어야 한다는 전제조건이 있다.

자세한 설명은 생략하지만, 사용자 정의 클래스를 검색하게 되는 경우에는 주의해라.
그래도 int형 같은 기본 데이터 타입은 신경쓰지 않아도 괜찮다.

*/

// 2. 다차원 배열, 가변 배열의 경우
/*
불가능하다.
*/

#endregion

#region 14) Array.Find (조건에 부합하는 요소의 획득)

// 1. 기본 정보
/*
어떠한 조건에 부합하는 요소를 받아오기 위해 사용하는 메서드이다.

이 메서드는 특이하게도 데이터 검색용의 메서드,
Predicate(술어) 라는 특수한 데이터 타입을 사용하여 요소를 검색한다.

=====

// 매개변수에 전달되는 값이 10 이상이라면 true를 반환하는 함수
static bool IsGTE10(int n)
{
    return n >= 10;
}

static void Main(string[] args)
{
    int[] nums1 = new int[] { 3, 16, 0, 7, 5 };
    int[] nums2 = new int[] { 1, 2, 3 };

    Predicate<int> isGTE10 = IsGTE10;

    int index1 = Array.Find(nums1, isGTE10);
    int index2 = Array.Find(nums2, isGTE10);

    Console.WriteLine(index1);
    Console.WriteLine(index2);

    Console.ReadLine();
}

=====

우선 조건 판단용으로 메서드를 작성한다.
사용자 정의 메서드 isGTE10은 인수로 전달한 값이 10 이상이라면
true를 반환하는 메서드이다.
(is greater than or equal to 10)
매개변수의 데이터 타입은 사용하는 배열의 데이터 타입에 맞춘다.

다음으로 Predicate<int> 라는 데이터 타입의 변수를 준비한다.
<> 안에는 방금 전에 작성한 메서드의 매개변수 데이터 타입을 입력한다.

Predicate<int>형 변수에는 아까 정의한 사용자 정의 메서드 IsGTE10을 대입한다.
여기서 메서드를 호출하는 것은 아니므로 함수 호출 연산자는 적지 않는다.
이 메서드의 실제 호출은 Array.Find 메서드가 담당한다.

마지막으로 Array.Find 메서드를 실행한다.
첫 번째 인수는 검색 대상 배열을 설정하며,
두 번째 인수에는 Predicate<int>형 변수를 지정한다.

반환값은 최초로 조건에 부합한 데이터이다.
만약 일치하는 요소가 없을 경우에는 기본값을 반환한다.
(int형의 경우에는 0)
Array.IndexOf 메서드와는 다르게 인덱스를 반환하지는 않으니 주의할 것.
*/

// 2. 람다식을 사용한 서술
/*
Array.Find 메서드는 '메서드를 준비하고 그것을 변수에 대입하고나서 사용한다'는
다소 귀찮은 순서가 필요하다.

이것은 람다식이라는 방법을 사용하면 조금 간결하게 표현할 수 있다.

=====

static void Main(string[] args)
{
    int[] nums = new int[] { 3, 16, 0, 7, 5 };

    int index = Array.Find(nums, (x) => x >= 10);

    Console.WriteLine(index);
    Console.ReadLine();
}

=====

*/

// 3. Array.Find의 이웃 함수
/*
술어를 사용하여 조건을 판단하는 메서드는 Find 이외에도 존재한다.
사용 방법은 비슷하기에 아래에 정리해두었다.

=====



=====


*/

#endregion

#endregion

#region string형 메서드

// 0. 문자열을 조작하기 위한 메서드
/*
C#에서는 string형이라는 문자열을 다루기 위한 전용 데이터 타입이 준비되어 있다.
단순히 string형 변수로 이용하여 문자열을 보관해두는 것 뿐만 아니라, 문자열의 일부를 추출하거나 가공할 수 있는 편리한 기능도 제공한다.

여기에서는 비교적 자주 사용하는 메서드(함수)의 일부를 소개한다.
이것이 전부는 아니다.

그리고 패스 문자열을 사용하는 경우에는 전용 메서드를 가져다 쓰는 것이 효율적 측면에서 더 좋다.

*/

// 1. string형의 기본
/*
문자와 문자열에서 설명했던 대로, 우선은 기본적인 내용을 복습한다.

=====

// 초기화
string str = "abc";

// 대입
str = "def";

// 문자열 결합
str += "ghi" //"defghi"

// 한 글자를 추출 (char형)
char c = str[1]; //'e'

// 문자열의 길이 (int형)
int length = str.Length; //6

// 공백
str = string.Empty;

//null
str = null;

// 공백의 존재 검사
if(str == string.Empty) {}

// null 검사
if(str == null) {}

// null 또는 공백 검사
if(string.IsNullOrEmpty(str)) {}

=====

string형 변수에는 null 이라는 특수한 값이 입력된 경우가 있다.
null이 대입된 상태의 string형 변수는 지금부터 설명하는 기능 모두를 사용할 수 없다.
(단, 대입이나 비교, null 검사 정도는 가능함)
*/

// 2. 특수한 초기화 방법
/*
그다지 사용 빈도는 높지 않지만 아래와 같은 초기화 방법도 존재한다.

=====

char[] chars = new char[] { 'a', 'b', 'c', 'd', 'e' };

// char형 배열을 string형으로 형변환하고 대입
string str1 = new string(chars);

// char형 배열의 1~3번째 문자를 string형으로 바꾸고 대입
string str2 = new string(chars, 1, 3);

// 문자 a를 10개 대입
string str3 = new string('a', 10);

=====
*/

// 3. string과 String
/*
C#에서는 string과 String 이라는 2가지 데이터 타입이 있다.
그런데 이들은 똑같은 것이라고 생각해도 상관없다.
string은 String의 또 다른 이름이기 때문.

예를 들어 공백을 나타내는 Empty는 string.Empty 또는 String.Empty
어느 쪽을 써도 상관없고 실행결과도 똑같다.

=====

string empty1 = string.Empty;
string empty2 = String.Empty;

=====

*/

#region 4. 메서드 목록

// 4-1. IsNullOrEmpty (null 또는 공백 검사)
/*
IsNullOrEmpty 메서드는 인수로 전달된 문자열이 null 또는 공백일 때 true를 반환한다.

=====

string str1 = "I have a pen";
string str2 = "";
string str3 = null;

Console.WriteLine(string.IsNullOrEmpty(str1));
Console.WriteLine(string.IsNullOrEmpty(str2));
Console.WriteLine(string.IsNullOrEmpty(str3));

=====

*/

// 4-2. ToUpper, ToLower (대문자 또는 소문자로의 변환)
/*
문자열을 대문자로 변환하기 위해서는 ToUpper 메서드를 사용한다.
문자열을 소문자로 변환하기 위해서는 ToLower 메서드를 사용한다.

=====

string str = "I have a pen";

//I HAVE A PEN
string strUpper = str.ToUpper();

//i have a pen
string strLower = str.ToLower();

=====

C#에서는 변수에 뒤이어 .(도트) 를 입력하는 것으로
해당 변수에 대해 부속된 여러 가지 메서드를 사용할 수 있다.
어떤 메서드가 사용 가능한 지는 변수의 데이터 타입에 따라 다르다.

ToUpper, ToLower 는 각각 변환한 후의 문자열을 string형으로 반환한다.
기존에 대입된 문자열은 바뀌지 않는다.

*/

// 4-3. Concat (문자열의 결합)
/*

문자열을 결합할 때 string.Concat 메서드를 사용한다.

=====

string str1 = "acb";
string str2 = "def";

string concat1 = string.Concat(str1, str2);
string concat2 = string.Concat(str1, ", ", str2);

Console.WriteLine(concat1);
Console.WriteLine(concat2);

=====

문자열을 결합하는 방법은 + 연산자 이외에도
메서드를 사용하는 방법이 있으니 취사선택에 맡긴다.

단, string.Concat 메서드로 지정할 수 있는 값은 4개까지이다.

*/

// 4-4. Join (배열의 결합)
/*

string형 배열의 요소에 구분 문자를 사용하고 결합할 경우에는
string.Join 메서드를 사용한다.

=====

string[] strs = new string[]
{
    "Apple",
    "Grape",
    "Orange"
};

string join = string.Join(":", strs);

Console.WriteLine(join);

=====

첫 번째 인수에는 사용하고 싶은 구분 문자를 지정한다.
두 번째 인수에는 연결하고 싶은 string형 배열을 지정한다.
반환값은 구분 문자로 연결된 문자열이다.

만약 구분 문자가 필요하지 않은 경우에는 공백 문자를 첫 번째 인수로 지정한다.

=====

string[] strs = new string[]
{
    "Apple",
    "Grape",
    "Orange"
};

string join = string.Join(string.Empty, strs);

Console.WriteLine(join);

*/

// 4-4-1. startIndex와 count
/*

세 번째 인수와 네 번째 인수를 숫자로 지정하여
결합할 요소의 시작 첨자(startIndex)와 결합할 요소 수(count)를 지정할 수 있다.

=====

string[] strs = new string[]
{
    "Apple",
    "Grape",
    "Orange",
    "Strawberry",
    "Peach"
};

// 배열의 두 번째 요소에서부터 3개를 결합
string join = string.Join(":", strs, 1, 3);

Console.WriteLine(join);

=====

*/

// 4-5. Split (구분 문자로 문자열 분할)
/*

문자열을 구분 문자로 분할하여 문자열 배열에 보관하기 위해서는
Split 메서드를 사용한다.

반환값은 문자열 배열이다.

=====

string str = "Apple,Grape,Orange";

string[] split = str.Split(',');

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

*/

// 4-5-1. 복수 문자 지정
/*

인수에 전달하는 구분 문자는 여러 개를 동시 지정할 수 있다.

=====

string str = "5+6-2=9";

string[] split = str.Split('+', '-', '=');

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

*/

// 4-5-2. 반환되는 배열의 요소 수를 제한 (count)
/*

구분 문자로써 사용하는 문자를 char형 배열로써 지정하고,
두 번째 인수에 숫자(count)를 지정하면 반환값의 배열 요소 수를
제한하는 것이 가능하다.

=====

string str = "5+6-2=9";

string[] split = str.Split(
    new char[] { '+', '-', '=' }, 3);

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

샘플 코드에서는 반환값의 배열 요소 수가 3이 된 시점에서 처리를 중지하였다.

*/

// 4-5-3. 비어 있는 요소를 삭제한 배열을 반환
/*

Split 메서든느 문자열의 분할에 있어 반환값으로 전달되는
배열 내부에 텅 비어 있는 요소(문자가 없는)가 포함될 수 있다.

아래의 샘플 코드에서는 배열 사이즈가 5이지만,
1, 3 요소는 공백 문자이다.

=====

string str = "Apple, Grape, Orange";

string[] split = str.Split(
    new char[] { ',', ' ' });

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

이런 비어 있는 요소를 반환값으로 전달하는 배열에 포함시키지 않을 경우
StringSplitOptions.RemoveEmptyEntries를 사용한다.

=====

string str = "Apple, Grape, Orange";

string[] split = str.Split(
    new char[] { ',', ' ' },
    StringSplitOptions.RemoveEmptyEntries);

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

문자열 분할 결과, 문자 수가 제로가 되는 요소는 반환값에서 제외되고
반환값의 배열 사이즈가 3이 된다.

*/

// 4-5-4. 구분 문자에 문자열을 지정
/*

구분 문자에 문자가 아닌 문자열을 지정하는 경우에는 아래와 같이 한다.

=====

string str = "Apple, Grape, Orange";

string[] split = str.Split(
    new string[] { ", " },
    StringSplitOptions.None);

for (int i = 0; i < split.Length; i++)
    Console.WriteLine(split[i]);

=====

우선 구분 문자로 사용하고 싶은 문자열을 배열로 작성한다.
(비록 하나 밖에 데이터가 없어도 배열로 작성해야 한다)

게다가 두 번째 인수에 StringSplitOptions.None 라든지
StringSplitOptions.RemoveEmptyEntries 중 하나를 전달해야 한다.

None은 반환값의 배열에 비어 있는 요소가 존재해도 그대로 반환한다.
RemoveEmptyEntries은 비어 있는 요소를 제외하고 반환한다.

=====

*/

// 4-6. Trim, TrimStart, TrimEnd (선두 및 후미의 공백 제거)
/*

문자열의 전후에 위치한 불필요한 공백을 제거하는 메서드이다.

선두에 있는 공백을 제거하려면 TrimStart,
후미에 있는 공백을 제거하려면 TrimEnd 를 사용한다.

=====

string str = "  I have a pen  ";

//「I have a pen」
string trim = str.Trim();

//「I have a pen  」
string trimStart = str.TrimStart();

//「  I have a pen」
string trimEnd = str.TrimEnd();

=====

상기 주석의 괄호는 보기 쉽도록 적어놓은 것이지 실제 출력되는 것은 아니다.
Trim을 통한 삭제대상 문자는 전/반각 스페이스, 개행 문자 중 하나이다.
그 이외에는 삭제처리를 하지 않는다.

*/

// 4-6-1. 지정한 문자를 삭제하기
/*
특정 문자를 삭제 대상으로 삼기 위해서는 인수에 문자(char형)을 지정한다.
이것은 여러 개를 동시지정하는 것도 가능하다.

=====

string str = " I have a pen.; ";

//「I have a pen」
string trim = str.Trim(' ', '.', ';');

=====

인수로 문자를 지정하면 그 문자만을 삭제대상으로 취급한다.
즉, 스페이스 같은 것들이 삭제대상으로 제외되니 예전과 같이 하려면
다시 한 번 명시적으로 작성해둘 필요가 있다.

게다가 문자열 중간에 지정해둔 문자가 있어도 삭제되지는 않는다.
어디까지나 문자열의 앞뒤에 위치한 불필요 문자를 삭제하는 메서드이기 때문.

=====

string str = " I have a pen ";

//「have a pen」
string trim = str.Trim(' ', 'I', 'a');

=====


*/

// 4-7. IndexOf (문자열의 검색)
/*

문자열 안에서 특정 문자를 검색하기 위해 사용하는 메서드이다.

=====

string str = "abcde";

int index1 = str.IndexOf('d'); //3

int index2 = str.IndexOf('z'); //-1

int index3 = str.IndexOf("cde"); //2

=====

선두에 위치한 문자를 0번째로 취급하고,
거기서부터 인수로 지정한 문자(char형) 또는 문자열(string형)을 검색하여 찾은 위치를 반환한다.

문자를 발견하지 못했을 경우에는 -1 을 반환한다.

=====

*/

// 4-7-1. 문자열의 중간에서부터 검색하기 (startIndex)
/*

IndexOf의 두 번째 인수에 startIndex 메서드를 지정하여 중간부터 검색이 가능하다.

=====

string str = "I have a pen";
int index = -1;

while(true)
{ 
    index = str.IndexOf('a', ++index);
    if (index >= 0)
        Console.WriteLine(index);
    else
        break;
}

=====

샘플 코드는 문자열 내부에서 a가 위치한 곳을 모두 표시한다.

첫 번째 루프에서는 0을, 다시 말해 선두에서부터 문자를 검색한다.

두 번째 루프에서는 이전 루프에서 발견한 위치에 1을 가산하고,
이전의 검출 위치 이후가 검색 범위로 변화한다.
(가산하지 않으면 이전 검출위치를 다시 검색하게 되므로 무한 루프에 빠진다)

변수 index를 -1 로 초기화하는 것은 이 가산하는 과정 때문.

*/

// 4-7-2. 검색 문자 수를 제한 (count)
/*

검색 시작 위치에서부터 N번째까지를 검색 대상으로 삼을 경우,
startIndex를 지정한 상태에서 세 번째 인수에 숫자(count) 를 추가로 지정한다.

=====

string str = "I have a pen";

// 0번째에서부터 마지막까지 검색
int index1 = str.IndexOf('a', 0); //3

// 0번째에서부터 3문자만큼의 분량만을 검색
int index2 = str.IndexOf('a', 0, 3); //-1

=====

*/

// 4-7-3. 대소문자를 구별하지 않음
/*

일반적으로는 대소문자를 구별하여 검출하지만,
두 번째 인수(startIndex를 사용하면 세 번째, count를 사용하면 네 번째)에
StringComparison.OrdinalIgnoreCase를 지정하여 대소문자를 구별하지 않고 검색할 수 있다.

=====

string str = "Apple, Grape, Orange";

int index1 = str.IndexOf("a");
int index2 = str.IndexOf("a", StringComparison.OrdinalIgnoreCase);

Console.WriteLine(index1);
Console.WriteLine(index2);

=====

하지만 StringComparison.OrdinalIgnoreCase 를 사용하는 경우에는
검색 대상 문자에 char형을 지정할 수 없게 된다.
(문자 1개더라도 무조건 string형으로 지정)

그리고 대소문자를 구별하지 않고 검색하기 위해서는
그 전에 ToUpper와 ToLower로 대문자 또는 소문자로 변환하고 검색한다는 방법도 있다.

하지만 일단 변환 처리가 들어가서 속도적인 측면으로 보면
StringComparison.OrdinalIgnoreCase 가 유리하다.

=====

string str = "Apple, Grape, Orange";

// 소문자로 변환하고나서 검색
int index1 = str.ToLower().IndexOf("a");

=====

*/

// 4-8. LastIndexOf (문자열의 후방검색)
/*
    IndexOf 메서드는 문자열의 처음부터 검색하지만, LastIndexOf는 마지막부터 검색한다.

    =====
    
    string str = "Hello, World!";
    
    int index = str.IndexOf('o'); // 4
    int lastIndex = str.LastIndexOf('o'); // 9

    =====

    어디까지나 '문자열을 뒤에서부터 검색'하는 것 뿐이라,
    반환되는 값은 '앞에서부터 실셈한 위치'이므로 주의하자.

*/

// 4-9. IndexOfAny (복수의 문자 검색)
/*
    첫 번째 인수에 지정된 char형 배열 안의 어떠한 문자가 첫등장하는 위치를 검색한다.

    =====

    string str = "I have a pen";
    char[] chars = new char[] { 'a', 'h', 'p' };

    int index1 = str.IndexOfAny(chars); //2

    //startIndex
    //5번째 문자부터 마지막까지를 검색
    int index2 = str.IndexOfAny(chars, 5); //7

    //startIndex, count
    //5번째 문자부터 2문자만큼 검색
    int index3 = str.IndexOfAny(chars, 5, 2); //-1

    =====

    여러 문자를 동시에 검색 대상으로 삼을 수 있다는 것을 제외하고 IndexOf와 동일하다.
    
    startIndex와 count 를 사용한 검색 방법도 가능하지만,
    문자열(string형)의 검색과 대소문자를 구별하지 않는 검색(StringComparison.OrdinalIgnoreCase)은 불가능하다.
*/

// 4-10. LastIndexOfAny (복수의 문자 후방검색)
/*
    LastIndexOfAny 메서드는 IndexOfAny의 후방검색판이다.
    IndexOf와 LastIndexOf의 관계와 동일하다.

    =====

    string str = "I have a pen";
    char[] chars = new char[] { 'a', 'h', 'p' };

    int index1 = str.LastIndexOfAny(chars); //9

    //startIndex
    int index2 = str.LastIndexOfAny(chars, 5); //3

    //startIndex, count
    int index3 = str.LastIndexOfAny(chars, 5, 2); //-1

    =====
*/

// 4-11. Contains (부분일치)
/*
    문자열 내부에 특정 문자열이 포함되는가를 판단하기 위해 사용하는 메서드이다.

    =====

    string str = "I have a pen";

    bool contains1 = str.Contains("ve a"); //true
    bool contains2 = str.Contains("apen"); //false

    =====

    IndexOf 처럼 문자의 위치를 반환하는 것이 아니라,
    포함되어 있는가 아닌가에 대한 판단 결과를 bool형으로 반환한다.
    그래서 위치 정보가 필요없는 경우에는 이쪽이 편리하다.
*/

// 4-12. StartsWith、EndsWith(전방일치, 후방일치)
/*
    문자열이 특정 문자열로 시작하는가를 판단하려면 StartsWith 메서드를 사용한다.
    반대로 특정 문자열로 끝나는가를 판단하려면 EndsWith 메서드를 사용한다.

    =====

    string str = "I have a pen";

    bool startsWith1 = str.StartsWith("I h"); //true
    bool startsWith2 = str.StartsWith("have"); //false

    bool endsWith1 = str.EndsWith("en"); //true
    bool endsWith2 = str.EndsWith("a"); //false

    =====

    이들 메서드는 두 번째 인수로 StringComparison.OrdinalIgnoreCase 를
    지정하여 대소문자를 구별하지 않고 판정을 내릴 수 있다.
*/

// 4-13. Equals (문자열 동등 비교)
/*
    A문자열이 B문자열과 똑같은지를 비교할 때에는 == (동등 연산자)를 사용한다.
    이외에도 Equals 메서드를 사용하는 방법도 있다.

    =====

    string str = "Pencil";

    bool op = str == "Pencil";          //true
    bool equals = str.Equals("Pencil"); //true

    =====

*/

// 4-13-1. Equals - 대소문자를 구별하지 않는다
/*

    두 번째 인수로 StringComparison.OrdinalIgnoreCase 를
    지정하여 대소문자를 구별하지 않고 판정을 내릴 수 있다.

    =====

        string str = "Pencil";

        //false
        bool op = str == "pencil";

        //true
        bool equals = str.Equals("pencil", StringComparison.OrdinalIgnoreCase);

    =====
*/

// 4-13-2. null 체크는 불가능
/*

Equals 메서드에서는 string형 변수의 null 검사가 불가능하니 주의할 것.
null 검사는 == 를 사용하든지 string.IsNullOrEmpty 메서드를 사용하는 것이 좋다.

=====

string str = null;

// 에러
bool equals = str.Equals(null);

=====

*/

// 4-13-3. 정적 메서드 버전
/*
Equals 메서드에는 정적 메서드 버전도 존재한다.
이쪽은 특이하게도 null 체크가 가능하다.

=====

string str = null;

bool equals = string.Equals(str, null); //true

=====

비교하고 싶은 변수의 데이터가 null이 될 가능성이 있을 경우는
정적 메서드 쪽을 사용하는 것이 권장된다.

*/

// 4-14. SubString (문자열의 부분 취득)
/*
문자열에서 일부를 전달받기 위해서는 SubString 메서드를 사용한다.

=====

string str = "I have a pen";

// 처음부터 끝까지 받아온다
string subString1 = str.Substring(7);

// 처음부터 n번째 문자까지만 받아온다
string subString2 = str.Substring(7, 3);

Console.WriteLine(subString1);
Console.WriteLine(subString2);

=====
*/

// 4-15. Remove (문자열의 부분 삭제)
/*
문자열에서 일부를 삭제하고 난 나머지를 받아오기 위해서 사용하는 메서드이다.

=====

string str = "I have a pen";

// 6번째 문자에서 마지막까지 삭제
string remove1 = str.Remove(6);

//6번째 문자부터 문자 3개 분량을 삭제
string remove2 = str.Remove(6, 3);

Console.WriteLine(remove1);
Console.WriteLine(remove2);

=====

*/

// 4-16. Replace (문자열의 교체)
/*
문자열의 일부를 다른 문자열로 바꾸기 위해서 사용하는 메서드이다.

Replace 메서드는 첫 번째 인수에 대상 문자열을 입력하고,
두 번째 인수에 바꾸고 싶은 문자열을 입력한다.

두 번째 인수에 공백을 지정하는 경우에는 특정 문자열을 일괄삭제할 수 있다.

=====

string str = "I have a pen";

string replace1 = str.Replace("a pen", "an apple");

// 반각 스페이스로 된 모두를 삭제
string replace2 = str.Replace(" ", string.Empty);

Console.WriteLine(replace1);
Console.WriteLine(replace2);

=====

*/

// 4-17. PadLeft & PadRight (문자열의 공백 메꾸기)
/*

PadLeft 메서드는 지정된 문자 수에 도달할 때까지 문자열 왼쪽을 공백으로 채운다.
PadRight 는 반대로 생각하면 된다.

숫자의 행을 맞추고 싶을 때 사용하면 편리하다.

=====

string str1 = "1";
string str2 = "20";

str1 = str1.PadLeft(4);
str2 = str2.PadLeft(4);

Console.WriteLine(str1);
Console.WriteLine(str2);

=====

*/

// 4-17-1. 지정된 문자로 채우기
/*
두 번째 인수에 문자(char형)를 지정하면 공백 대신에 해당 문자로 메꾼다.

=====

string str1 = "1";
string str2 = "20";

str1 = str1.PadLeft(4, '0');
str2 = str2.PadLeft(4, '*');

Console.WriteLine(str1);
Console.WriteLine(str2);

=====
*/

// 4-18. string.Compare (문자열의 순서 비교)
/*

2개의 문자열을 비교하여 정렬 순서를 정수로 반환하는 메서드이다.

=====

string str1 = "Apple";
string str2 = "Orange";
string str3 = "Grape";

//-1
int compare1 = string.Compare(str1, str2);

//1
int compare2 = string.Compare(str2, str3);

//0
int compare3 = string.Compare(str1, str1);

=====

Apple 과 Orange 를 알파벳 순으로 정렬했을 경우 전자가 앞쪽에 위치한다.
이 때 Compare 메서드는 -1을 반환한다.

Orange와 Grape를 알파벳 순으로 정렬했을 경우 후자가 앞쪽에 위치한다.
이 때 Compare 메서드는 1을 반환한다.

비교하는 문자열이 동일할 경우 Compare 메서드는 0을 반환한다.

이 메서드는 주로 배열과 같은 데이터의 정렬에 사용한다.
단순히 2개의 문자열이 똑같은지 아닌지만을 판단하고 싶다면 Equals 메서드를 사용할 것.

*/

// 4-18-1. 대소문자를 구별하지 않음
/*
Compare 메서드는 세 번째 인수로 StringComparison.OrdinalIgnoreCase를
사용할 경우 대소문자에 의존하지 않고 판정을 내린다.
*/

#endregion

#endregion

#region List 클래스

// 1. List 클래스에 대하여
/*
배열을 사용하면 동일한 데이터 타입의 변수를 일괄적으로 관리할 수 있다.
여기서 한 번 더 발전하여 C#에서는 List 클래스라고,
배열을 한층 더 고도화한 문법이 탑재되어 있다.

=====

// 배열
int[] arrNum = new int[] { 1, 2, 3, 4, 5 };
for (int i = 0; i < arrNum.Length; i++)
{
    Console.Write("{0], ", arrNum[i]);
}

// List 클래스
List<int> lstNum = new List<int>() { 1, 2, 3, 4, 5 };
for (int i = 0; i < lstNum.Count; i++)
{
    // 각 요소에 대한 접근 방식은 배열과 동일하다
    Console.Write("{0}, ", lstNum[i]);
}

=====

List 클래스를 사용하기 위해서는 소스 코드 최상단에
using System.Collections.Generic; 를 입력해야 한다.

대부분의 경우 비주얼 스튜디오를 주요 컴파일러로 사용하고 있어
해당 내용이 자동으로 입력되니 크게 신경 쓸 필요는 없다.

=====

List<데이터 타입> 변수명 = new List<데이터 타입>();

List<데이터 타입> 변수명 = new List<데이터 타입>() {초기화 데이터 목록};

List<데이터 타입> 변수명 = new List<데이터 타입> {초기화 데이터 목록};

=====

배열은 초기화할 때 사이즈를 숫자로 지정할 수 있었지만,
List 에는 그러한 기능이 탑재되어 있지 않아
초기화 데이터를 직접 지정하지 않으면 초기에는 무조건 0으로 설정된다.
(생성자를 사용하는 방법도 있긴 하지만 지금 중요한 것은 아님)

이렇게 선언과 초기화를 끝낸 List는 배열과 거의 비슷한 방법으로 사용한다.
내부의 각 요소에 대한 접근은 첨자 연산자를 사용한다.

*/

// 2. 사이즈
/*

배열은 Length 프로퍼티를 사용하여 내부 크기를 전달받지만,
List 클래스는 Count 프로퍼티를 사용한다.

=====

// int형 데이터를 취급하는 List 클래스
List<int> lstNum = new List<int>() { 1, 2, 3, 4, 5 };

// List 클래스의 크기값이 그대로 전달됨
int count = lstNum.Count;

=====

*/

// 3. 제네릭 컬렉션 (Generic Collections)
/*
코드 최상단의 using System.Collections.Generic 처럼
이 기능은 컬렉션에 포함된 기능 중에서 제네릭 컬렉션이라는 이름으로 분류되어 있다.

컬렉션(Collections)이라는 것은 데이터의 집합을 의미한다.
배열도 컬렉션의 일종이지만 이것은 C#의 지극히 기본적인 기능이므로
별도의 설명은 생략한다.

제네릭에 관해서는 나중에 따로 설명하겠지만,
미리 간단하게 말하자면 임의의 데이터 타입을 인수로써 전달받는 기능이다.

'임의의 데이터 타입을 바탕으로 한 변수'가 아니라
'임의의 데이터 타입'을 인수로써 받는다는 뜻.

예를 들어 List 클래스는 int형, string형,
그 외 사용자 정의 자료형을 비롯한 여러 데이터 타입을
형식 매개 변수로써 지정하여 특정 데이터 타입의 집합을 다룰 수 있다.
(형식 매개 변수 : 데이터 타입을 매개 변수로써 취급)

List 클래스는 컬렉션과 제네릭의 기능을 모두 가지고 있어
제네릭 컬렉션의 일종으로 취급한다.
(이외에도 Queue<T>, Stack<T>, Dictionary<TKey, TValue> 가 있음)

C#에서 제네릭 컬렉션이 추가됨에 따라 그 전까지 사용하던
일반 컬렉션은 사용하지 않게 되었다.
*/

// 4. 데이터 타입의 자동 추론
/*

List 클래스의 일반적인 선언은 List<>을 2번 적어야 하다 보니
약간 번거로움을 느끼는 때가 많아 데이터 타입을 자동으로 추론해주는
var 를 자주 사용하곤 한다.

=====

// 기존의 작성 방법
List<int> lstNum = new List<int>() {1,2,3,4,5};

// 데이터 타입 자동 추론
var lstNum = new List<int>() {1,2,3,4,5};

=====

*/

// 5. List 클래스의 장점
/*
List 클래스와 배열 간의 차이점에서 가장 뚜렷한 것이,
동적으로 요소를 확보하고 언제든지 삭제할 수 있다는 점이다.

=====

var lst = new List<int>() { 0, 1, 2, 3 };

// 9라는 정수를 추가한다
lst.Add(9);

foreach (var n in lst)
    Console.Write("{0}, ", n);

Console.WriteLine();

// 2라는 정수를 삭제한다
lst.Remove(2);

foreach (var n in lst)
    Console.Write("{0}, ", n);

Console.WriteLine();

=====

상기 소스 코드를 배열로 구성하는 경우에는 상당히 손이 많이 가서 귀찮아지지만,
List 클래스라면 메서드 하나만으로 신속하게 처리가 가능하다.

물론 요소 수가 이미 확정되어 있고 증감할 일이 없을 경우에는
클래스보다 배열을 사용하는 편이 더 좋을 수 있다.

하지만, 체감이 될 정도로 속도 차이가 날 일은 없다고 봐도 무방하여
배열 대신에 List 클래스를 사용해도 아무런 문제는 없다.

*/

// 6. List 클래스의 복사
/*
List 클래스는 배열과 똑같은 참조 타입이다.
즉, List형 변수는 또 다른 List형 변수를 대입한 것만으로 복사가 이루어지지 않는다.

=====

List<int> lst1 = new List<int>() {1, 2, 3};

// lst2는 lst1의 또 다른 이름일 뿐이다
List<int> lst2 = lst1;

=====

List 클래스를 복사하기 위해서는 List를 선언할 때
소괄호 안에 List 클래스의 변수를 전달하는 방법으로 진행해야 한다.

=====

List<int> lst1 = new List<int>() { 1, 2, 3 };

// 생성자의 인수로 전달하여 데이터 복사
List<int> lst2 = new List<int>(lst1);

lst1[1] = 9; // 데이터가 어떻게 되나 테스트를 겸해 대입 처리

foreach (var n in lst1)
    Console.Write("{0}, ", n);

Console.WriteLine();

foreach (var n in lst2)
    Console.Write("{0}, ", n);

=====

이외에도 ToList 메서드를 호출하여 데이터를 복사하는 것도 가능하다.
.ToList() 를 사용하려면 소스 코드 최상단에 using System.Linq; 입력이 필요하다.

해당 메서드를 통한 복사는 얕은 복사 (Shallow Copy)라고 한다.
참조 타입을 요소로 취급하는 List의 복사는
주소의 복사에 불과하기 때문에 조심해서 사용해야 한다.

=====

List<int> lst1 = new List<int>() { 1, 2, 3 };

// lst1의 데이터를 복사한다
List<int> lst2 = lst1.ToList();

=====
*/

// 7. 요소의 어긋남
/*

List의 요소는 원하는 대로 삭제할 수 있지만 주의할 것이 있다.
요소를 삭제할 때 삭제한 요소 뒤에 위치한 다음 요소가 한 칸 앞으로 이동한다.

삭제 메서드를 단독으로 사용할 경우에는 문제 없지만,
반복문에서 삭제 메서드를 호출한다면 상황이 달라진다.

=====

static void Main(string[] args)
{
    var lst = new List<string>()
    { "Apple", "Grape", "Orange", "Strawberry", "Peach"};

    // List에서 문자 수가 6 미만인 요소를 모두 삭제
    for (int i = 0; i < lst.Count; i++)
        if (lst[i].Length < 6) lst.RemoveAt(i);

    for (int i = 0; i < lst.Count; i++)
        Console.WriteLine(lst[i]);
}

=====

Grape 의 문자 수는 5임에도 불구하고 삭제되지 않는다는 문제가 있다.
이것은 앞서 Apple 이 삭제될 때 뒤에 위치한 요소가
앞으로 이동하면서 일어나는 현상 때문이다.

다시 말해서 Apple가 삭제되면 다음에 위치한 요소의 위치 이동으로
점차 어긋남에 따라 Grape의 첨자가 0에 이르기에 처리가 안 되는 것.

그럼에도 불구하고 루프 카운터 변수가 멈추질 않으니
Grape의 문자 수 판단이 제대로 처리되지 않고 넘어가는 결과를 보여준다.

이를 해결하기 위해 선두가 아닌 후미에서부터 데이터를 삭제하여
요소가 앞으로 쏠리는 현상을 방지한다.

=====

static void Main(string[] args)
{
    var lst = new List<string>()
    { "Apple", "Grape", "Orange", "Strawberry", "Peach"};

    // List에서 문자 수가 6 미만인 요소를 모두 삭제
    // 데이터의 삭제를 역순으로 한다
    for (int i = lst.Count - 1; i >= 0; i--)
        if (lst[i].Length < 6) lst.RemoveAt(i);

    for (int i = 0; i < lst.Count; i++)
        Console.WriteLine(lst[i]);
}

=====

*/

#endregion

#region List 클래스의 메서드

// 1. Add (요소의 추가)
/*

=====

// 빈 List를 작성
var lst = new List<int>();

lst.Add(2);
lst.Add(3);
lst.Add(5);

=====

C++의 std::vector에서 push_back() 을 사용할 때와 동일한 효과.
List 클래스의 가장 마지막에 데이터를 추가한다.

*/

// 2. Insert (요소의 추가)
/*
=====

var lst = new List<string>() {"Apple", "Grape", "Strawberry"};

// 두 번째 위치에 Orange 를 추가한다
lst.Insert(1, "Orange");

// 네 번째 위치에 Peach 를 추가한다
lst.Insert(3, "Peach");

for (int i = 0; i < lst.Count; i++)
    Console.WriteLine("{0}: {1}", i, lst[i]);

=====

첫 번째 인수에 데이터를 추가할 위치, 두 번째 인수에 추가하고 싶은 요소를 지정한다.
만약 첫 번째 인수가 0 미만이거나 List의 사이즈보다 클 경우 에러를 출력한다.

*/

// 3. AddRange (List의 결합)
/*
List 의 마지막에 다른 List를 결합할 경우에는 AddRange 를 사용한다.

=====

var lst1 = new List<int>() { 1, 2, 3 };
var lst2 = new List<int>() { 4, 5, 6 };

// lst1의 끄트머리에 lst2의 데이터를 결합
lst1.AddRange(lst2);

foreach(var n in lst1)
    Console.WriteLine(n);

=====
*/

// 4. InsertRange (List의 삽입)
/*

List 중간에 다른 List를 삽입할 경우에는 InsertRange를 사용한다.

첫 번째 인수에는 데이터를 삽입할 요소 위치를 지정하며,
두 번째 인수에는 추가하고 싶은 List 변수를 지정한다.

첫 번째 인수가 0 미만 또는 List의 사이즈 이상의 값일 경우 에러를 출력한다.

=====

var lst1 = new List<string>() {"Apple", Strawberry", "Peach"};
var lst2 = new List<string>() {"Orange", "Grape"};

// lst1의 첫 번째 요소 위치에 lst2 전체를 추가
lst1.InsertRange(1, lst2);

foreach(var s in lst1)
    Console.WriteLine(s);

=====

*/

// 5. Remove (요소의 삭제)
/*
=====

var lst = new List<string>()
{ "Apple", "Strawberry", "Peach", "Orange", "Grape" };

// 데이터 삭제
bool bo1 = lst.Remove("Peach");
bool bo2 = lst.Remove("Strawberry");
bool bo3 = lst.Remove("Peach");

foreach (var s in lst)
    Console.WriteLine(s);

=====

요소를 발견하고 삭제에 성공한 경우는 True를,
요소를 발견하지 못했을 경우에는 False를 반환한다.

동일한 값이 여럿 존재할 경우에는 가장 처음에 발견한 요소 만을 삭제하니 주의할 것.


*/

// 6. RemoveAt(특정 요소의 삭제)
/*

값 자체가 아닌 요소 번호를 지정하여 요소를 삭제한다.

=====

var lst = new List<string>()
{ "Apple", "Strawberry", "Peach", "Orange", "Grape" };

// 첨자 연산자를 이용하여 데이터 삭제
lst.RemoveAt(1);
lst.RemoveAt(3);


=====

0 미만 혹은 List의 전체 요소 수 이상의 값을 지정하면 에러를 출력한다.

마지막을 제외한 요소를 삭제하면
삭제한 요소 다음에 위치해있던 요소들이 1칸씩 앞으로 이동한다.
때문에 요소 번호가 바뀌니 주의할 것.

Remove 메서드와 다르게 반환값이 존재하지 않는다.

*/

// 7. RemoveRange (범위 지정 삭제)
/*
=====

var lst = new List<string>()
{ "Apple", "Strawberry", "Peach", "Orange", "Grape" };

// 두 번째 요소 위치부터 데이터를 2개 삭제
lst.RemoveRange(1, 2);

=====

범위를 지정하여 요소를 (일괄)삭제하는 메서드이다.

첫 번째 인수는 삭제를 시작할 요소 번호를 입력하며,
두 번째 인수에는 삭제할 요소의 갯수를 정한다.

*/

// 8. RemoveAll (조건부 삭제)
/*

어떠한 조건을 만족하는 요소를 모두 삭제하는 메서드이다.

이 메서드는 조건 판단용 메서드와 Predicate(술어)라는
특수한 데이터 타입을 사용하여 요소를 검색하고 그것과 일치한 요소를 삭제하는 구조이다.

=====

// 전달된 데이터가 10 이상이면 참을 반환하는 메서드
static bool IsGTE10(int n)
{
    return n >= 10;
}

static void Main(string[] args)
{
    var lst = new List<int>() { 8, 3, 16, 19, 2, 31 };
    Predicate<int> isGTE10 = IsGTE10;

    int removed = lst.RemoveAll(isGTE10);

    foreach (var n in lst)
        Console.WriteLine(n);

    Console.WriteLine("삭제된 요소 수: {0}", removed);

    Console.ReadLine();
}

=====

먼저 조건 판단용 메서드를 정의한다.

상기 예제에서는 10 이상의 요소를 요소를 삭제하기 위해,
인수가 10 이상이면 참을 반환하는 메서드를 작성하였다.

다음으로 Predicate<int> 라는 데이터 타입으로 변수를 하나 입력.
<> 안에는 방금 전 작성한 메서드의 인수로써 전달한 변수가 사용한 데이터 타입을 전달한다.

이어서 변수명을 기술하고 변수에는 방금 전 정의된 메서드를 대입한다.
여기서 메서드를 호출하지는 않으므로 소괄호를 붙일 필요는 없다.
실질적인 메서드 호출은 RemoveAt 메서드가 담당한다.

이 Predicate형 변수는 RemoveAll 메서드를 지정함으로써
조건을 만족하는 요소를 모두 삭제할 수 있다.

반환값은 삭제된 요소의 갯수이다.

=====

※ 람다식을 사용하면 Predicate와 조건 판단용 메서드를 사용할 필요가 없다

var lst = new List<int>() { 8, 3, 16, 19, 2, 31 };

int removed = lst.RemoveAll((x) => x >= 10);

foreach (var n in lst)
    Console.WriteLine(n);

Console.WriteLine("삭제된 요소 수: {0}", removed);

=====


*/

// 9. Clear (모든 요소 삭제)
/*
List의 요소를 모두 삭제하는 메서드이다.
해당 메서드를 사용한 뒤에 요소 수는 0이 된다.

=====

var lst = new List<int>() { 0, 1, 2, 3, 4, 5 };

lst.Clear(); // 요소를 모두 삭제

Console.WriteLine(lst.Count); // 0이 출력됨

=====

※ List 클래스 자체가 불필요해진 경우라면 변수 자체에 null을 대입한다

static void Func()
{
    var lst = new List<int>() { 0, 1, 2, 3, 4, 5 };
    lst.Clear();

    // 더 이상의 사용을 안 하겠다는 표시
    lst = null;
}

=====

C#에는 가비지 컬렉션(Garbage Collection)이라고 하는 특수한 시스템이 있는데,
이것은 불필요한 데이터를 자동으로 메모리에서 삭제하는 역할을 수행한다.

클래스의 변수(인스턴스)는 보편적으로 참조형에 속한다.
여기에 null을 대입한다는 것은 메모리 상에서 어떠한 곳도
가리키고 있지 않다는 의미로써 해석을 하게 되는데,
이는 지금까지 인스턴스가 저장하고 있던 데이터도 사용할 수 없다는 의미로
시스템이 받아들여 가비지 컬렉션이 할당한 메모리를 해제하는 것.

위 예제와 같은 로컬 변수는 현재의 스코프를
벗어난 시점에서 수명이 다 한 것이라 볼 수 있다.
그래서 가비지 컬렉션이 작동하여 메모리도 동시에 정리를 해준다.

Func 메서드의 코드 블록의 실효성은 크지 않은 편에 속하지만,
멤버 변수에 대한 수명이 어느 정도인지는 가늠이 잘 되지 않기에
명시적으로 데이터를 삭제하고 싶다면 저렇게 null을 대입하는 것이 유효하다.

=====

static void Func()
{
    var lst1 = new List<int>() {0, 1, 2, 3};
    var lst2 = lst1;

    // lst1에 null 을 대입해도 0~3까지의 데이터가 사라지진 않음
    // 해당 데이터는 현재 lst2 가 참조하고 있기 때문
    lst1 = null;
}

=====
*/

// 10. ToArray (List를 배열로 변경)
/*
List를 배열로 바꿀 때 사용하는 메서드이다.

=====

var lst = new List<int>() { 1, 2, 3 };

// List를 배열로 변경하여 저장한다
int[] arr = lst.ToArray();

foreach (var n in arr)
    Console.WriteLine(n);

=====

List에서 사용하는 데이터 타입이 참조 타입일 경우에는
주소의 복사가 될 수도 있다는 점에 주의.

무슨 말이나면 ToArray 적용 후에 원본 List에서 값을 바꾸면
변환한 후의 배열에도 영향을 준다.

=====

static void Main(string[] args)
{
    var lst = new List<int[]>()
    {
        new int[] {1, 2},
        new int[] {3, 4}
    };

    // 가변 배열에 List의 요소를 배열로 변경 후 대입
    int[][] arr = lst.ToArray();

    // List의 첫 번째 요소(배열)의 첫 번째 데이터 값을 변경
    lst[0][0] = 9;

    foreach (var x in arr)
        foreach (var y in x)
            Console.WriteLine(y);
}

*/

// 11. GetRange (요소의 일부 복사)
/*
List에서 특정 범위를 복사하는 메서드이다.

=====

var lst1 = new List<int>() { 6, 11, 2, 9, 4 };

// lst1의 첫 번째 요소부터 시작해 데이터 3개 분량만큼 묶어 복사
var lst2 = lst1.GetRange(1, 3);

foreach (var n in lst2)
    Console.WriteLine(n);

=====
*/

// 12. Sort (요소의 정렬)
/*
List의 모든 데이터를 오름차순으로 정렬하는 메서드이다.

=====

var lst = new List<int>() { 0, 3, 12, 7, 1 };
lst.Sort();

foreach (var n in lst)
    Console.Write("{0}, ", n);

=====
*/

// 13. Reverse (정렬의 반전)
/*
요소의 정렬 순서를 반전시키는 메서드이다.

=====

var lst = new List<int>() { 5, 7, 11, 2, 9 };

// 전체 데이터의 순서 반전    
lst.Reverse();

// 첫 번째 요소를 포함한 3개의 데이터 순서를 반전
lst.Reverse(1, 3);

foreach (var n in lst)
    Console.WriteLine(n);

=====
*/

// 13-1. 내림차순으로 정렬
/*

Reverse 메서드는 내림차순이 아닌 현재 순서를 반전시키는 역할을 담당한다.
내림차순으로 바꾸기 위해서는 오름차순으로 먼저 정렬을 해둬야 한다.

=====

var lst = new List<int>()
    { 5, 7, 11, 2, 9 };

lst.Sort();
lst.Reverse();

foreach (var n in lst)
    Console.Write("{0}, ", n);

=====

*/

// 14. Contains (요소 존재 판정)
/*

List 내부 요소에 특정 값이 존재하고 있는지를 판단할 때 사용한다.

=====

var lst = new List<int>() { 2, 3, 5, 7, 11 };

Console.WriteLine(lst.Contains(7));
Console.WriteLine(lst.Contains(8));

=====

지정된 값이 요소 목록 내부에서 하나라도 있다면 참을 반환한다.
요소가 위치한 장소(인덱스)를 알고 싶다면 IndexOf, LastIndexOf 를 사용한다.

*/

// 15. IndexOf (요소 검색)
/*

List에서 특정 요소를 검색하기 위해서 사용하는 메서드이다.

=====

var lst = new List<int>() { 2, 3, 5, 7, 11 };

int index1 = lst.IndexOf(7);
int index2 = lst.IndexOf(8);

Console.WriteLine(index1);
Console.WriteLine(index2);

=====

요소를 처음부터 검색하여 최초로 발견한 정보에 대한 번호를 반환한다.
발견하지 못했을 경우에는 -1을 반환한다.

어떠한 값이 존재하고 있는지에 대한 결과를 얻고 싶으면
IndexOf 보다는 Contains 메서드를 추천한다.

제2인수, 제3인수를 지정하는 것으로 조금 더 유연한 검색이 가능하다.

=====

var lst = new List<int>() { 0, 3, 12, 7, 1, 0, 6 };

// List의 시작부터 0을 검색
int index1 = lst.IndexOf(0);

// 2번째 위치부터 0을 검색
int index2 = lst.IndexOf(0, 2);

// 2번째 위치부터 3칸만 이동하며 0을 검색
int index3 = lst.IndexOf(0, 2, 3);

Console.WriteLine(index1);
Console.WriteLine(index2);
Console.WriteLine(index3);

=====

예를 들어 List 내에 포함된 타겟을 모두 표시하려면 아래와 같이 입력한다.

=====

List<int> lst = new List<int> { 0, 12, 16, 0, 7, 0, 3 };
int index = -1;

// 0이 출력되는 위치를 모두 표시
while (true)
{
    // 이전에 발견한 요소 이후를 검색 대상에 포함시키기 위해 1을 가산한다
    index = lst.IndexOf(0, index + 1);
    if (index >= 0)
    {
        Console.WriteLine(index);
        continue;
    }
    break;
}

*/

// 16. LastIndexOf (요소 후방검색)
/*

IndexOf 메서드는 요소를 List의 처음부터 검색하지만,
뒤에서부터 검색하고 싶은 경우에는 LastIndexOf 메서드를 사용한다.

=====

var lst = new List<int>() { 0, 3, 12, 7, 1, 0, 6 };

// 전방검색
int index = lst.IndexOf(0);

// 후방검색
int lastIndex = lst.LastIndexOf(0);

Console.WriteLine(index);
Console.WriteLine(lastIndex);

=====

요소 검색의 시작점이 후방이라는 것 말고는 IndexOf와 동일하다.

제2인수, 제3인수를 지정하여 검색 범위를 설정하는 것마저 똑같으나,
반환값은 뒤에서부터가 아닌 앞에서부터 세어 출력하므로 주의할 것.

*/

// 17. BinarySearch (요소 이분 검색)
/*

요소의 검색에는 보통 IndexOf 메서드를 사용하지만,
BinarySearch 메서드를 사용하는 경우도 있다.

BinarySearch는 이분 검색이라고도 불리는 방법을 사용하며,
처음부터 순서대로 검색하는 IndexOf 메서드보다 고속으로 작동한다.

다만 BinarySearch 메서드는 검색대상이 오름차순으로
정렬이 되어 있는 상태여야만 한다는 전제조건이 따라붙는다.

이것은 BinarySearch를 사용하기 전에
Sort 메서드가 필수로 사용되어야 한다는 뜻이다.

=====

var lst = new List<int>()
    { 5, 7, 11, 2, 9 };

var item = 7;

lst.Sort();

int index = lst.BinarySearch(item);

foreach (var n in lst)
    Console.Write("{0}, ", n);
Console.WriteLine();

Console.WriteLine("「{0}」は{1}番目", item, index);

=====

*/

// 18. Find (조건에 부합하는 요소 획득)
/*

어떠한 조건을 지정하고 일치하는 요소를 반환하는 메서드이다.

Find 메서드는 RemoveAll 메서드와 마찬가지로
Predicate 키워드를 사용한다.

=====

// 인수가 10 이상이면 참을 반환하는 메서드
static bool IsGTE10(int n)
{
    return n >= 10;
}

static void Main(string[] args)
{
    var lst = new List<int>() { 8, 3, 16, 19, 2, 31 };

    Predicate<int> isGTE10 = IsGTE10;

    int find = lst.Find(isGTE10);

    Console.WriteLine(find);

    Console.ReadLine();
}

=====

샘플 코드에서는 10 이상의 요소를 List 내에서 검색하고
최초로 발견한 요소를 반환하고 있다. (요소 번호가 아닌 요소 그 자체를 반환)

만약 발견하지 못했을 경우에는 기본값을 반환한다.
(int형일 경우 0)

*/

// 18-1. Find 메서드의 친구
/*

Predicate를 사용하여 구체적인 조건을 확립하는 메서드는 이외에도 존재한다.
사용 방법은 Find와 똑같으니 구체적인 내용은 아래를 참조.

=====

static bool IsGTE10(int n)
{
    return n >= 10;
}

static void Main(string[] args)
{
    var lst = new List<int>() { 8, 3, 16, 19, 2, 31 };
    Predicate<int> isGTE10 = IsGTE10;

    // 최초로 발견한 요소를 반환한다
    int find =
        lst.Find(isGTE10);

    // 최후로 발견한 요소를 반환한다
    int findLast =
        lst.FindLast(isGTE10);

    // 최초로 발견한 요소의 번호를 반환한다
    int findIndex =
        lst.FindIndex(isGTE10);

    // 최후로 발견한 요소의 번호를 반환한다
    int findLastIndex =
        lst.FindLastIndex(isGTE10);

    // 조건에 부합하는 모든 요소를 List로 반환한다
    List<int> findAll =
        lst.FindAll(isGTE10);

    // 조건에 부합하는 모든 요소를 참/거짓으로 반환한다
    bool exists =
        lst.Exists(isGTE10);

    // 모든 요소가 조건에 부합하는지를 참/거짓으로 반환한다
    bool trueForAll =
        lst.TrueForAll(isGTE10);

    Console.Write("검색대상 List: ");
    foreach (var n in lst)
        Console.Write("{0}, ", n);
    Console.WriteLine("\n검색조건: n >= 10\n");

    Console.WriteLine("Find: {0}", find);
    Console.WriteLine("FindLast: {0}", findLast);
    Console.WriteLine("FindIndex: {0}", findIndex);
    Console.WriteLine("FindLastIndex: {0}", findLastIndex);

    Console.Write("FindAll: ");
    foreach (var n in findAll)
        Console.Write("{0}, ", n);
    Console.WriteLine();

    Console.WriteLine("Exists: {0}", exists);
    Console.WriteLine("TrueForAll: {0}", trueForAll);

    Console.ReadLine();
}

=====

FindIndex 메서드와 FindLastIndex 메서드는
요소를 발견하지 못했을 경우에 -1을 반환한다.

또한 이들 메서드는 오버로드가 포함되어 있다.

=====

static bool IsGTE10(int n)
{
    return n >= 10;
}

static void Main(string[] args)
{
    var lst = new List<int>() { 0, 1, 12, 3, 4, 15 };
    Predicate<int> isGTE10 = IsGTE10;

    // 3번째 요소부터 검색 시작
    int findIndex1 = lst.FindIndex(3, isGTE10);

    // 3번째 요소부터 2칸만 이동하며 검색
    int findIndex2 = lst.FindIndex(3, 2, isGTE10);

    // 4번째 요소부터 검색 시작
    int findLastIndex1 = lst.FindLastIndex(4, isGTE10);

    // 4번째 요소부터 2칸만 이동하며 검색
    int findLastIndex2 = lst.FindLastIndex(4, 2, isGTE10);

    Console.WriteLine(findIndex1);
    Console.WriteLine(findIndex2);

    Console.WriteLine(findLastIndex1);
    Console.WriteLine(findLastIndex2);

    Console.ReadLine();
}

*/

#endregion

#region Dictionary 클래스

// 1. Dictionary 클래스에 대하여
/*
데이터 집합을 다룰 때에 배열과 List 클래스의 뒤를 이어
사용빈도가 대단히 높은 클래스가 Dictionary 클래스이다.

Dictionary 클래스는 이름 그대로 사전 관련 별명으로 부르거나
특성을 그대로 살려 연관 배열(Associative Array)으로 부른다.

배열과 List 클래스는 요소에 대한 접근에 사용하는 첨자에
숫자를 사용하지만 Dictionary 클래스는 데이터 타입을 사용한다.

=====

using System;
using System.Collections.Generic; //←이게 필요

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //Dictionary 클래스
            Dictionary<string, int> dct = new Dictionary<string, int>();

            //요소 추가
            dct.Add("Apple", 120);
            dct.Add("Grape", 220);
            dct.Add("Orange", 90);

            //「Apple」요소를 출력
            Console.WriteLine(dct["Apple"]);

			// 요소를 모두 출력
            foreach(KeyValuePair<string, int> kvp in dct)
            {
                Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
            }

            Console.ReadLine();
        }
    }
}

=====

List 클래스와 똑같이 Dictionary 클래스를 사용하기 위해서는
코드 최상단에 using System.Collections.Generic; 선언이 필요하다.

*/

// 2. 문법
/*

=====

Dictionary<데이터타입1, 데이터타입2> 변수명 = new Dictionary<데이터타입1, 데이터타입2>();

Dictionary<데이터타입1, 데이터타입2> 변수명 = new Dictionary<데이터타입1, 데이터타입2>() { 초기화 리스트 };

Dictionary<데이터타입1, 데이터타입2> 변수명 = new Dictionary<데이터타입1, 데이터타입2> { 초기화 리스트 };

=====

기본적으로 List 클래스의 선언과 동일하지만,
Dictionary 클래스는 데이터 타입을 2개 지정하고 있다.

배열과 List 클래스는 각 요소의 접근에서 첨자로써 숫자를 사용한다.
이 숫자는 요소의 처음부터 순서대로 자동으로 배치된다.

반면 Dictionary 클래스는 첨자에는 임의의 값을 지정한다.
단순한 숫자라도 상관없고 문자열도 상관없지만,
이 첨자는 자동으로 배치되지 않으므로 첨자를 일일이 입력해야 한다.

「데이터타입1」에는 첨자로 사용할 데이터 타입을 지정한다.
「데이터타입2」에는 저장될 요소가 사용할 데이터 타입을 지정한다.

첨자로 사용하는 값을 Key, 데이터로 사용할 값을 Value라고 한다.

*/

// 2-1. 선언과 초기화
/*

Dictionary<string, int> dct = new Dictionary<string, int>()
{
    //{ 첨자, 요소 },
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

*/

// 3. 요소 추가와 접근
/*
요소는 첨자 연산자를 사용하여 데이터를 추가하는 것 이외에
Add 메서드로도 추가할 수 있다.

=====

Dictionary<string, int> dct = new Dictionary<string, int>();

// Apple 이라는 이름으로 120을 추가
dct["Apple"] = 120;

// Grape 이라는 이름으로 220을 추가
dct.Add("Grape", 220);

// Apple 의 데이터에 접근
int num = dct["Apple"]; //120

// Apple의 데이터를 다른 값으로 덮어쓰기
dct["Apple"] = 150;

=====

List는 요소의 추가에 전용 메서드를 사용하지만,
Dictionary는 존재하지 않는 Key에 값을 대입하는 것으로
직접 요소를 추가할 수 있다.
지정한 Key가 이미 존재할 경우에는 Value를 덮어쓴다.

그리고 Add 메서드는 제1인수에 Key를, 제2인수에는 Value를 지정한다.
각각의 데이터 타입은 처음 선언했던 데이터 타입을 그대로 사용한다.

각 요소에 대한 접근은 배열과 똑같이 첨자 연산자를 사용하지만,
첨자로써 사용하는 데이터는 Key이다.
Key에 string형을 지정하였으면 문자열로 각 요소에 접근하게 된다는 의미.

Key와 Value를 관련지어 다룰 수 있다는 것이 연관 배열의 최대 특징.
만약 Key에 int형을 지정하였다면 일반 배열처럼 숫자를 첨자로써 다루게 된다.

*/

// 3-1. Add 메서드로는 기존의 Key에 지정 불가능
/*
Dictionary 클래스는 Key로 요소에 접근하기 때문에
동일한 Key를 가진 또 다른 요소를 동시에 저장할 수 없다.

이미 존재하는 Key를 Add 메서드로 추가할 경우 에러를 출력한다.
(덮어쓰기가 불가능)

=====

Dictionary<string, int> dct = new Dictionary<string, int>();

dct.Add("Apple", 120);
dct.Add("Apple", 150); //에러

// 이건 가능
//「150」으로 덮어쓰기
dct["Apple"] = 150;

=====

Key에 문자열을 지정한 경우에는 대소문자를 구별한다.
하지만 가독성 측면에서 바람직하진 않으니 추천하는 방법은 아니다.

=====

Dictionary<string, int> dct = new Dictionary<string, int>();

dct.Add("Apple", 120);
dct.Add("apple", 150); // 가능

=====

*/

// 4. 모든 요소의 열거
/*
Dictionary 클래스는 사용자가 직접 Key를 정의하기 때문에
가령 int형을 Key로 지정한다고 해서 0부터 순서대로 정렬되지 않는다.
이러한 특성 때문에 for문을 통해 접근할 수 없다.

Dictionary 클래스의 요소를 열거하기 위해서는 foreach문을 사용하며,
foreach문에 따라 추출되는 각 요소는 KeyValuePair라는 특수한 데이터로 취급한다.
(public readonly struct KeyValuePair<TKey,TValue>)

=====

Dictionary<string, int> dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

foreach (KeyValuePair<string, int> kvp in dct)
{
    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
}

=====

Dictionary 클래스는 사실 KeyValuePair 구조체의 집합이며,
foreach문으로 값을 추출할 경우의 데이터 타입이
KeyValuePair이라는 것으로 그 사실을 증명한다.

KeyValuePair는 Key와 Value 라는 2개의 프로퍼티를 가진다.
이것은 Key는 요소명, Value라는 데이터를 가진 Dictionary 클래스의 정의와 동일하다.

foreach문의 루프 카운터 변수는 기본적으로 값을 수정할 수 없어
이 방법을 사용하면 Dictionary의 값을 바꿀 수 없다.

값을 바꾸는 방법은 후술.
*/

// 4-1. 정렬 순서는 정해지지 않음
/*
Dictionary 클래스는 List 클래스와 다르게 요소를 정렬한다는 개념이 존재하지 않는다.

즉 foreach문을 비롯한 반복문을 사용하여 데이터를 출력했을 때,
클래스 내부의 데이터가 가지런하게 줄을 지어 나올 가능성은 없다는 뜻이다.
(추가하는 순서에 국한되지 않음)

데이터가 순서대로 정렬되는 것을 전제로 개발하는 프로그램은 버그의 원인 중 하나이다.
만약 이러한 사양이 요구되는 프로그램이면 List 클래스를 사용한다.
*/

// 4-2. 데이터 타입 추론
/*
Dictionary 클래스는 문장의 길이가 쉽게 늘어질 수 있기 때문에
데이터 타입을 자동 추론하는 var를 자주 사용한다.

=====

var dct = new Dictionary<string, int>()
{
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

foreach (var kvp in dct) //KeyValuePair<string, int>
{
    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
}

=====
*/

// 5. 요소 수
/*
List 클래스와 동일하게 Count 프로퍼티를 사용한다.

=====

Dictionary<string, int> dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

Console.WriteLine(dct.Count); //3

=====

*/

// 6. Key, value를 모두 획득
/*

데이터를 저장해 둔 상태의 Dictionary 클래스에서
모든 Key를 받아오기 위해서는 Keys 프로퍼티를,
모든 Values를 받아오기 위해서는 Values 프로퍼티를 사용한다.

=====

var dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

// Key를 모두 획득
Dictionary<string, int>.KeyCollection keys = dct.Keys;

// Value를 모두 획득
Dictionary<string, int>.ValueCollection values = dct.Values;

foreach (string k in keys)
{
    Console.WriteLine(k);
}

foreach (int v in values)
{
    Console.WriteLine(v);
}

=====

그리고 프로퍼티를 통해 추출한 데이터의 형태는
각각 KeyCollection, ValueCollection 이라는 이름을 가지고 있다.

이 상태로는 구체적인 데이터의 취급이 불가능하며, (foreach로 나열하는 것은 가능)
아래 설명할 CopyTo 메서드를 사용하여 배열로 변환해야 한다.

*/

// 6-1. CopyTo
/*
Dictionary 클래스의 Keys, Values 프로퍼티로 추출한 데이터를
배열로 변환시켜주는 메서드이다.

=====

var dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

string[] keys = new string[dct.Count];
int[] values = new int[dct.Count];

dct.Keys.CopyTo(keys, 0);
dct.Values.CopyTo(values, 0);

Console.WriteLine(keys[0]);
Console.WriteLine(values[0]);

=====

제1인수 : 데이터가 복사될 배열을 지정한다.
제2인수 : 데이터가 복사될 배열의 복사 시작 위치를 지정한다.

데이터를 복사할 배열의 크기가 부족할 경우에는 에러를 출력한다.

*/

// 6-2. ToList
/*

Keys, Values 프로퍼티의 ToList 메서드를 사용하면
데이터 타입이 즉시 List 로 변화하여 배열로 바꾸는 수고를 덜 수 있다.

단, ToList를 사용하려면 using System.Linq; 의 입력이 필요하다.
특별한 이유가 없는 한 이쪽을 사용하는 것이 편리할 것이다.

=====

var dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

var keys = dct.Keys.ToList();
var values = dct.Values.ToList();

Console.WriteLine(keys[0]);
Console.WriteLine(values[0]);

=====

*/

// 7. foreach문을 통한 요소 교체
/*

앞서 foreach문을 통한 데이터의 대입은 불가능하다고 했으나,
Keys 프로퍼티를 사용하면 안전하게 처리할 수 있다.

=====

var dct = new Dictionary<string, int>(){
    { "Apple", 120 },
    { "Grape", 220 },
    { "Orange", 90 },
};

// Keys 프로퍼티를 List로 변환
var keys = dct.Keys.ToList();

foreach (var key in keys)
{
    dct[key] *= 2; // 대입
}

foreach (var kvp in dct)
{
    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);
}

=====

먼저 Dictionary의 Keys 프로퍼티로 배열이나 List로 변환한다.

이것은 foreach문으로 열거중인 컬렉션을 고치는 경우 에러를 발생시키므로
원본 Dictionary 클래스와는 별개의 오브젝트로써 만들어두기 위함이다.

foreach문에서는 이 Keys 리스트(또는 배열)를 열거한다.
나머지는 루프 내에서 추출된 Key를 Dictionary 클래스의 첨자로 지정하고
각 요소에 값을 바꿔주면 끝.

*/

#endregion

#region Dictionary 클래스의 메서드

// 1. Add (요소의 추가)
/*

Dictionary 클래스에 요소를 추가하는 메서드이다.

=====

// Dictionary 작성
var dct = new Dictionary<string, int>();

// 요소 추가
dct.Add("aaa", 5);
dct.Add("bbb", 7);
dct.Add("ccc", 9);

foreach (var kvp in dct)
    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);

=====

제1인수 : Key로 사용할 데이터를 지정한다.
제2인수 : Value로 사용할 데이터를 지정한다.

각각 설정한 데이터는 Dictionary 클래스의 주요 성분으로 변화한다.

Add 메서드는 요소의 추가 밖에 수행할 수 없어 기존 값을 덮어쓰는 기능은 존재하지 않는다.
이미 존재하는 Key를 지정하는 경우에는 에러를 출력한다.

=====

var dct = new Dictionary<string, int>();

dct.Add("aaa", 5);

// 에러
dct.Add("aaa", 10);

// OK
dct["aaa"] = 10;

=====

*/

// 2. Remove (요소의 삭제)
/*

Remove 메서드는 요소의 삭제에 사용하는 메서드이다.
삭제에 성공한 경우에는 True를, 대상을 찾지 못했을 경우에는 False를 반환한다.

=====

var dct = new Dictionary<string, int>() {
    { "aaa", 5 },
    { "bbb", 7 },
    { "ccc", 9 },
};

// 데이터를 삭제
bool bo1 = dct.Remove("bbb"); //true
bool bo2 = dct.Remove("zzz"); //false

foreach (var kvp in dct)
    Console.WriteLine("{0}: {1}", kvp.Key, kvp.Value);

=====


*/

// 3. Clear (요소의 전체 삭제)
/*

Dictionary 클래스 내부에 존재하는 모든 데이터를 삭제하는 메서드이다.

=====

var dct = new Dictionary<string, int>() {
    { "aaa", 5 },
    { "bbb", 7 },
    { "ccc", 9 },
};

// 요소를 모두 삭제
dct.Clear();

Console.WriteLine(dct.Count); //0

=====

*/

// 4. ContainsKey (특정 Key의 존재 여부)
/*

특정 Key를 가진 요소가 클래스 내부에 존재하는지 검사하는 메서드이다.

=====

var dct = new Dictionary<string, int>() {
    { "aaa", 5 },
    { "bbb", 7 },
    { "ccc", 9 },
};

bool bo1 = dct.ContainsKey("aaa"); //true
bool bo2 = dct.ContainsKey("zzz"); //false

=====

*/

// 5. ContainsValue (특정 Value의 존재 여부)
/*

특정 Value를 가진 요소가 클래스 내부에 존재하는지 검사하는 메서드이다.

=====

var dct = new Dictionary<string, int>() {
    { "aaa", 5 },
    { "bbb", 7 },
    { "ccc", 9 },
};

bool bo1 = dct.ContainsValue(5); //true
bool bo2 = dct.ContainsValue(999); //false

=====

*/

// 6. TryGetValue (특정 Key & Value의 획득)
/*

특정 Key를 가진 요소가 클래스 내부에 존재하는 경우,
해당 데이터에 대응하는 Value를 받아오는 메서드이다.

=====

var dct = new Dictionary<string, int>() {
    { "aaa", 5 },
    { "bbb", 7 },
    { "ccc", 9 },
};

int tryGetValue1;
int tryGetValue2;

bool bo1 = dct.TryGetValue("aaa", out tryGetValue1); //true
bool bo2 = dct.TryGetValue("zzz", out tryGetValue2); //false

Console.WriteLine(tryGetValue1);
Console.WriteLine(tryGetValue2);

=====

이 메서드의 특이한 점은 제2인수에 out 키워드를 사용한다는 것이다.

제1인수로 지정한 Key가 클래스 내부에 존재한다면
거기에 연결된 Value를 제2인수로 지정한 변수에 저장한다.

만약 Key가 존재하지 않을 경우에는 기본값을 반환한다.

반환값은 Key를 발견했을 때 True, 발견하지 못했을 때 False.

*/

#endregion

//=======

#region Random

// 1. Random 클래스
/*
C#에서 난수를 사용하기 위해서는 Random 클래스를 사용한다.
(해당 클래스는 System 네임스페이스에 존재함)

난수를 생성하는 메서드는 Random 클래스의 인스턴스 메서드로써 준비되어 있으며,
Random 클래스 인스턴스는 기존의 클래스 인스턴스 생성 방법과 동일하다.

=====

// 랜덤 인스턴스 생성
Random r = new Random();

=====

*/

// 2. 정수의 랜덤
/*
정수에 대한 난수는 Next 메서드를 통해 획득한다.

Next 메서드에 인수를 적용하지 않았을 경우,
0 ~ int.MaxValue까지의 범위에서 임의로 하나를 추출한다.
(0 ~ 21억까지의 범위)

인수를 1개 지정하면 0 이상 인수 미만의 값을 추출한다.
인수를 2개 지정하면 첫 번째 인수 이상, 두 번째 인수 미만의 값을 추출한다.

어떠한 경우라도 최대값은 지정한 인수 미만이 되니 주의.

=====

static void Main(string[] args)
{
    // 랜덤 인스턴스
    Random r = new Random();

    // 0 이상의 난수
    int rValue1 = r.Next();

    // 0 이상 10 미만의 난수
    int rValue2 = r.Next(10);

    // 100 이상 1000 미만의 난수
    int rValue3 = r.Next(100, 1000);

    // 데이터 확인
    Console.WriteLine(rValue1);
    Console.WriteLine(rValue2);
    Console.WriteLine(rValue3);
}

=====

*/

// 3. 실수의 랜덤
/*
실수에 대한 난수는 NextDouble 메서드를 통해 획득한다.

특이한 점은 NextDouble 메서드는 인수를 지정하지 않으며,
0.0 이상 1.0 미만의 값을 double형 데이터로써 반환한다.

인수가 필요없다는 특징 때문에 특정 범위의 결과값을 원한다면
수식을 이용하여 반환값의 결과에 변화를 줘야 한다.

=====

static void Main(string[] args)
{
    // 랜덤 인스턴스
    Random r = new Random();

    // 0 이상 1 미만의 실수
    double rValue1 = r.NextDouble();

    // 0 이상 10 미만의 실수
    double rValue2 = r.NextDouble() * 10;

    // -1 이상 1 미만의 실수
    double rValue3 = r.NextDouble() * 2 - 1;
}

=====

*/

// 4. Next 메서드를 사용한 소수
/*
=====

static void Main(string[] args)
{
    // 랜덤 인스턴스
    Random r = new Random();

    // 0 이상 1 미만의 실수
    double rValue1 = r.Next() / (double)int.MaxValue;

    // 0 이상 1 이하의 실수
    double rValue2 = r.Next() / (double)(int.MaxValue - 1);
}

=====

Next 메서드는 0부터 int.MaxValue 까지의 범위에서
난수를 추출하기에 이를 다시 int.MaxValue로 나누면
0~1 사이의 소수를 구할 수 있다.

단, int형끼리의 연산 결과는 int형이 되니 반드시 어느 한 쪽을
double 또는 float로 캐스트해줘야 정상적인 결과를 전달받을 수 있다.

*/

// 5. 랜덤 바이트 배열
/*
랜덤으로 구성된 바이트 배열을 만들려면 NextBytes 메서드를 사용한다.
인증 관련 데이터에 필요한 바이트 값을 준비할 때 이용하고는 한다.

=====

static void Main(string[] args)
{
    // 랜덤 인스턴스
    Random r = new Random();

    byte[] bytes = new byte[4];
    r.NextBytes(bytes);

    // BitConverter 클래스를 통해 Bytes 배열을 16진수로 변환
    Console.WriteLine(BitConverter.ToString(bytes));

    // 기존의 10진수로 표현
    foreach (var b in bytes)
        Console.Write("{0} ", b);
}

=====
*/

// 6. 시드(Seed)
/*
Random 클래스의 인스턴스 생성 시 인수(int형)를 전달할 수 있다.
만약 시드가 동일한 인스턴스를 생성했다면
거기서 추출된 난수도 똑같은 것을 볼 수 있다.

반면 생성자를 사용하지 않았을 경우에는 자동으로
Environment.TickCount 라는 값이 시드로써 전달된다.

Environment.TickCount는 시스템 시작된 이후부터
지금까지의 시간(밀리초 단위)을 정수값으로 환산한 것이다.

=====

Random r1 = new Random();
Random r2 = new Random();

// 동일한 Seed를 사용하고 있어 동일한 데이터가 나올 가능성 높음
Console.WriteLine(r1.Next(100));
Console.WriteLine(r2.Next(100));

=====

이러한 코드는 직전의 인스턴스 생성부터 다음 인스턴스 생성까지
걸리는 시간이 1ms 도 걸리지 않아 똑같은 시드를 사용하고 있을
가능성이 높다.

똑같은 프로그램을 오차 없이 완전히 같은 시간에 시작하는 경우는
좀처럼 보기 힘들어서 복수의 인스턴스를 생성하지 않고
하나를 여러 곳에 돌려쓴다면 위와 같은 문제는 발견하기 어렵다.

하지만 예를 들어 멀티 스레딩 프로그램처럼
스레드마다 Random 클래스의 인스턴스를 필요로 할 때가 있다.
이 때는 생성자마다 다른 값을 전달해준다.

=====

Random r1 = new Random(1);
Random r2 = new Random(2);

Console.WriteLine(r1.Next(100));
Console.WriteLine(r2.Next(100));

=====

그러나 이 코드도 다음 번 프로그램을 실행할 때 동일한 시드가 전달되니
또 다시 같은 난수를 보게 될 가능성이 적지 않다.

프로그래밍에서 산 넘어 산이라는 결과를 볼 수는 없기 때문에
Environment.TickCount 를 사용하여 시작할 때마다
새로운 값을 시드로써 활용할 수 있도록 만들어줘야 한다.

=====

Random r1 = new Random(Environment.TickCount + 1);
Random r2 = new Random(Environment.TickCount + 2);

Console.WriteLine(r1.Next(100));
Console.WriteLine(r2.Next(100));

=====

*/

#endregion

#region 델리게이트(delegate)

// 1. delegate의 정의
/*

Delegate = 위임, 위탁

델리게이트(Delegate)라는 것은 메서드(함수)를 변수처럼 다루는 기능이다.
쉽게 말해 C/C++에서 사용하였던 함수 포인터와 거의 비슷하다.

델리게이트는 메서드 처리를 동적으로 전환할 수 있게 도와주는 문법이며,
설명을 들어도 쉽게 이해가 가지 않을 수 있어 순서대로 설명한다.

=====

// 델리게이트의 정의
delegate int MyDelegate(int a, int b);

static void Main(string[] args)
{
}

=====

델리게이트의 정의는 메서드의 정의와 상당히 닮아있다.
작성하는 위치도 일반적인 메서드와 크게 다를 곳이 없는 Main 메서드의 옆이다.

먼저 delegate 키워드를 사용하여 델리게이트의 선언을 명시한다.
이어서 반환값, 델리게이트명, 매개변수의 정의 순서로
일반 메서드와 동일한 순서대로 입력을 진행한다.
마지막에 세미콜론을 입력하는 것으로 델리게이트의 정의는 종료.

델리게이트는 메서드의 매개변수와 그 데이터 타입, 그리고 반환값의 데이터 타입만을 정의한다.
샘플 코드에서는 '매개변수로 int형을 2개 가지고 있고,
int형 데이터를 반환하는 MyDelegate라는 이름을 가진 delegate형 데이터를 정의하였다.

이로써 delegate형이라는 새로운 데이터 타입을 정의하였고,
기존의 데이터 타입과는 다르게 메서드를 저장할 수 있는 특수한 녀석으로써 취급한다.

그러나 델리게이트에는 메서드의 처리가 존재하지 않아 이대로 사용할 수 없다.
그래서 아래와 같은 내용을 작성한다.

=====

// 델리게이트의 정의
delegate int MyDelegate(int a, int b);

// 정의한 델리게이트와 동일한 매개 변수, 동일한 반환 자료형의 메서드
static int TestMethodA(int x, int y)
{
    return x + y;
}

static void Main(string[] args)
{
    // MyDelegate형 변수의 선언
    // 동일한 매개 변수, 반환 자료형을 가진 메서드를 저장
    MyDelegate md = TestMethodA;

    // 예전 선언 방식
    //MyDelegate md = new MyDelegate(TestMethodA);

    // TestMethodA 메서드 실행
    int num = md(3, 6);
    
    Console.WriteLine(num);
    Console.ReadLine();
}

=====

우선 MyDelegate형과 똑같은 매개 변수,
그리고 반환 자료형을 가진 메서드로써 TestMethodA를 정의하였다.

다음으로 MyDelegate형 변수 md를 선언하여 TestMethodA를 대입.
이 때 함수 호출 연산자는 사용하지 않는다.
괄호를 입력하면 메서드를 호출하는 것으로 오인하기 때문.

new 키워드를 사용하여 MyDelegate형 변수를 선언하고 대입하는 방법도 있지만,
어느 쪽을 사용해도 MyDelegate형과 동일한 형태를 가진 녀석만 대입이 가능하다.

아무튼 이것으로 변수 md는 TestMethodA 메서드가 저장된 상태로 변화하였다.
변수 md는 일반 메서드와 똑같이 함수 호출 연산자와 필요한 인수를 전달하는 것으로
TestMethodA를 실행할 수 있게 된다.

그럼 이제 위 샘플 코드를 약간 변형하여 아래와 같이 입력해본다.

=====

delegate int MyDelegate(int a, int b);

static int TestMethodA(int x, int y)
{
    return x + y;
}

static int TestMethodB(int x, int y)
{
    return x * y;
}

static void Main(string[] args)
{
    MyDelegate md;
    if (true)
        md = TestMethodA;
    else
        md = TestMethodB;

    int num = md(3, 6);
}

=====

똑같은 매개 변수, 똑같은 반환 자료형을 가진 메서드를 1개 더 정의한다.
MyDelegate형 변수 md에 대입하는 메서드는 조건에 따라 변화하는 것을 볼 수 있다.

이처럼 작성하였을 경우에 변수 md는
'조건에 따라 호출되는 메서드가 다르다'는 상태에 놓이게 된다.
이것이 바로 delegate의 특징이다.

따라서 델리게이트는 필요에 따라 어떠한 메서드의 처리를
다른 메서드의 처리로 교체할 수 있게 해주는 문법이라고 요약할 수 있다.

=====

*/

// 2. delegate의 용도
/*

델리게이트의 특징은 '호출하는 방법은 유지하면서
(메서드를 이용한) 처리는 다르게 만든다'는 것이다.

예를 들어 메서드의 매개 변수에 델리게이트를 사용하면
메서드 내부 처리를 별도로 작성하지 않고 다른 쪽으로
옮겨탈 수 있다는 뜻이다.

=====

// 델리게이트 정의
delegate bool MyPredecate(int x);

// 매개변수가 10 이상이면 참을 반환하는 메서드
static bool IsGTE10(int n)
{
    return n >= 10;
}

// 매개변수가 짝수라면 참을 반환하는 메서드
static bool IsEven(int n)
{
    return n % 2 == 0;
}

// 배열에서 조건에 부합하는 요소를 추출하는 메서드
//「조건」은 매개 변수로 사용하는 델리게이트로 지정 가능
static int[] Select(int[] arr, MyPredecate predicate)
{
    // 조건에 부합하는 요소의 갯수를 센다
    int count = 0;
    foreach (var x in arr)
        if (predicate(x))
            count++;

    // 반환값이 될 배열을 선언
    int[] ret = new int[count];

    // 반환값이 될 배열에 값을 대입
    count = 0;
    foreach (var x in arr)
        if (predicate(x))
            ret[count++] = x;

    return ret;
}

static void Main(string[] args)
{
    int[] nums = new int[]
        { 2, 4, 7, 8, 11, 14, 18, 19 };

    int[] arr1 = Select(nums, IsGTE10);
    int[] arr2 = Select(nums, IsEven);

    foreach (var n in arr1)
        Console.Write("{0} ", n);

    Console.WriteLine();

    foreach (var n in arr2)
        Console.Write("{0} ", n);            

    Console.ReadLine();
}

=====

【실행결과】

11 14 18 19
2 4 8 14 18

=====

MyPredecate는 int형 매개 변수 1개, bool형 데이터를 반환하는 델리게이트이다.
IsGTE10 메서드와 IsEven 메서드의 매개 변수와 반환값은 MyPredecate와 똑같다.
즉 MyPredecate 로도 IsGTE10의 기능을 그대로 활용할 수 있다.

Select 메서드는 int형 배열과 MyPredecate 를 매개 변수로 취하고 있다.
foreach문에서 배열 요소를 하나씩 전달받아
매개 변수 predicate에 값을 전달하고 조건을 검사한다.

Select 메서드 안에서 어떤 조건 판단용 메서드를 사용할 지는
메서드를 호출할 때에 구체적으로 결정하고 있다.

또한, 여기에서는 직접 델리게이트를 정의해둔 상태이지만,
샘플 코드에서 사용한 델리게이트와 똑같은(것처럼 보이는) 것을
C# 표준에서 제공하고 있다.

=====

// System 네임스페이스에 정의되어 있는 delegate
public delegate bool Predicate<T>(T obj);

=====

// ↑를 사용할 경우
static int[] Select(int[] arr, Predicate<int> predicate)
{
    //생략
}

=====

이 델리게이트도 여러 가지 데이터 타입을 인수로 전달받을 수 있다.
List 클래스와 Dictionary 클래스 등의 데이터 타입을
자유롭게 설정할 수 있는 점은 기존의 Delegate와 똑같다.

*/

// 3. 정의된 delegate
/*
델리게이트에서 사용하는 delegate형은 사용자가 직접 정의하는 문법이지만,
사실 C#에서는 자주 사용하는 형태를 미리 준비해두었다.

=====

bool Predicate<T>(T obj)
  - 매개 변수가 조건과 부합하는가?

TOutput Converter<TInput, out TOutput>(TInput input)
  - TInput을 TOutput으로 변환한다

int Comparison<T>(T x, T y)
  - x와 y를 비교
  - x가 작으면 0 미만의 값을 반환
  - x가 크면 0 보다 큰 값을 반환
  - 똑같은 값이라면 0을 반환

=====
*/

// 4. Action 델리게이트
/*

public delegate void Action<in T>(T obj);

Action 델리게이트는 더욱 유연하게 데이터 타입을 다루는 문법이다.

반환값이 존재하지 않고(void형), 매개 변수를 0~4개 취급하는 델리게이트.
.NET Framework 4.0 이후부터는 매개 변수를 16개까지 취급하도록 변화하였다.

=====

static void Main(string[] args)
{
    int value = 0;

    // Action에 저장할 함수에 매개 변수가 필요한 경우 파라미터를 정의해둔다
    // Action 인스턴스 생성과 동시에 func1 메서드를 저장
    Action<int> del_func_inst = func1;

    del_func_inst += func2;
    del_func_inst += func3;

    // Action을 통해 func1, func2, func3 를 호출
    del_func_inst(value);
}

static void func1(int val)
{
    Console.WriteLine("func1 is executed. val + 1 = {0}.\n", val + 1);
    return;
}
static void func2(int val)
{
    Console.WriteLine("func2 is executed. val + 2 = {0}.\n", val + 2);
    return;
}
static void func3(int val)
{
    Console.WriteLine("func3 is executed. val + 3 = {0}.\n", val + 3);
    return;
}

=====

【실행결과】

// Action에 저장된 순서대로 순차 실행
func1 is executed. val + 1 = 1.
func2 is executed. val + 2 = 2.
func3 is executed. val + 3 = 3.

=====
*/

// 5. Func 델리게이트
/*
Func 델리게이트는 반환값이 존재하며 매개 변수를 0~4개 취하는 델리게이트이다.
.NET Framework 4.0 이후부터는 매개 변수를 16개까지 취급하도록 변화하였다.
Action 델리게이트와의 차이점은 반환값이 존재한다는 것.

일반적으로 매개 변수가 4개 이상이 되는 메서드는 쓸 일은 그렇게 많지 않으며,
하물며 16개 이상을 사용하는 메서드는 일부러 찾기에도 힘든 수준이니
C#에서 델리게이트를 직접 정의해서 사용하는 일은 잘 없다.

=====

static void MethodA1() { }
static void MethodA2(int x) { }
static void MethodA3(int x, float y) { }

static int MethodF1() { return 0; }
static bool MethodF2(int x) { return false; }
static string MethodF3(int x, float y) { return "abc"; }

static void Main(string[] args)
{
    Action action1 = MethodA1;
    Action<int> action2 = MethodA2;
    Action<int, float> action3 = MethodA3;

    Func<int> func1 = MethodF1;
    Func<int, bool> func2 = MethodF2;
    Func<int, float, string> func3 = MethodF3;
}

=====

Action 델리게이트의 데이터 타입 지정은 매개 변수의 데이터 타입 지정에도 사용된다.
매개 변수가 존재하지 않는 메서드는 지정할 필요가 없다.

Func 델리게이트의 데이터 타입 지정은 우선 매개 변수의 데이터 타입을 지정하고,
마지막으로 반환값의 데이터 타입을 지정하는 순서대로 이루어진다.

매개 변수를 전달받지 않는다고 해도 반환값은 존재하고 있으니
무조건 하나는 데이터 타입을 지정해야 한다.

예를 들어 Func 델리게이트를 사용하여 위 예제의 Select 메서드를 고쳐 쓴다면 다음과 같다.

=====

// 이제 이걸 쓸 일은 없음
//delegate bool MyPredecate(int x);

// 배열에서 조건에 부합하는 요소를 추출하는 메서드
//「조건」은 매개 변수인 Func 델리게이트로 지정할 수 있음
static int[] Select(int[] arr, Func<int, bool> func)
{
    // 조건에 걸맞는 요소의 갯수를 센다
    int count = 0;
    foreach (var x in arr)
        if (func(x))
            count++;

    // 반환값이 될 배열을 선언
    int[] ret = new int[count];

    // 반환값이 될 예정인 배열에 값을 대입
    count = 0;
    foreach (var x in arr)
        if (func(x))
            ret[count++] = x;

    return ret;
}

=====

*/

#endregion