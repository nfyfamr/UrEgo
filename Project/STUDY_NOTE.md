# Note

## [Setting Splash Screen](https://docs.unity3d.com/Manual/class-PlayerSettingsSplashScreen.html)
- 프로그램을 구동할 때 가장 처음, 화면에 로고가 fade in/out 하는 장면이 있는데, 이를 Splash Screen 이라고 한다.
- 유니티 라이선스에 따라 이 Splash Screen 을 수정하는데 제한이 걸려있는데, Personal 권한의 경우 다음과 같은 제한이 있다.
    - Unity Splash Screen 기능을 끌 수 없다.
    - Unity Logo 를 끌 수 없다.
    - Splash Screen의 투명도를 최대 0.5까지 밖에 설정할 수 없다.
- Splash Screen Setting은 Edit > Project Settings > Player > Splash Image > Splash Screen 에서 할 수 있다.
- Preview 버튼으로 설정된 Splash Screen 이 어떻게 보여지는 확인 할 수 있다.


## [텍스트 이미지를 만들 수 있는 사이트](https://cooltext.com/)

## [GameObject fading in/out](https://forum.unity.com/threads/fading-in-out-gui-text-with-c-solved.380822/)
- Coroutine 의 사용이 필요하다.
- Coroutine 내에서 알파값을 시간에 비례해서 더하거나 뺌
    t.color = new Color(t.color.r, t.color.g, t.color.b, 1.0f);
    ... t.color.a - (Time.deltaTime / 1.0f)

## [GameObject Destroying](https://answers.unity.com/questions/860004/unity-46-ui-destroy-problem.html)
- StartUI에서 Controller로 넘어가가기 위해 StartUI를 다음과 같은 코드로 파괴하려고 했는데, Script 컴포넌트들에 의존성이 있어 Canvas를 없앨 수 없다는 에러가 발생했다.
    Destroy(GetComponent<Canvas>());
- Component가 아니라 GameObject를 삭제해야 함.

## [이벤트 트리거](https://m.blog.naver.com/PostView.nhn?blogId=mrbinggrae&logNo=220522481681&proxyReferer=https%3A%2F%2Fwww.google.co.kr%2F)
- 블록을 클릭했을 때, 해당 블록이 사라지고 그 블록에 정의된 기능이 실행되는 것을 이벤트 트리거를 통해 구현가능.
- 블럭에 EventTrigger 컴포넌트를 추가하고 Pointer Click Event Type을 추가한다. Pointer Click은 마우스 클릭 또는 터치할 때 발생하는 이벤트 타입이다.
- 다음으로 이벤트를 추가하고 설정을 Editor And Runtime, 타겟 오브젝트로 AbilityPanel을 선택하고, 타겟 오브젝트에 등록된 스크립트의 DestoryBlock 메서드를 등록한다.
- AbilityPanel에서 관리하는 blocks 리스트는 스태틱으로해야 한다.
- 이벤트 트리거가 동작할 때, 등록한 DestroyBlock 메서드로 BaseEventData를 매개변수로 전달하면서 실행한다.
- BaseEventData의 selectedObject 변수를 사용하기 위해서는 해당 오브젝트가 selectable 해야 한다.
- 그러므로 블록 오브젝트에 Selectable 컴포넌트를 추가한다.

  


