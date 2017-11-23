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

  


