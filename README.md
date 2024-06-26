# FOX IN THE FOREST3

## 프로젝트 소개
플레이어가 몬스터를 물리치며 숲 속을 탐험하는 게임  
게임 종류: 2d 플랫포머

<img src="https://github.com/Lee-Kyung-Sup/2DPlatformer_Together/assets/120997897/896deb5f-f197-4760-9935-508d0a08c07e" width="400" height="300" />

<br>

## 개발기간
* 24.02.27 ~ 24.03.05


### 멤버 구성
- 유시아 : **UI 참여, 플레이어 움직임, 일반몬스터, 보스몬스터, 체력바 구현, 피해와 체력관리, 사운드**
- 장영재 : **UI 참여, NPC 제작, 상점 구현 및 플레이어와 상호 작용**
- 이경섭 : **맵 전체 제작, 플레이어 발판 밑에서 통과구현, 발판떨어지는것 구현, 발판 리스폰구현**
- 홍용욱 : **기획, PM, PPT, 회의록 작성, 테스터, 영상 작업**
- 심선규(팀장) :
- (팀노션)<[https://www.notion.so/7-7-7-7fac2c85c86d44a39b630219e69ce406](https://www.notion.so/teamsparta/X2-c618d7c7da96429b9ad97fc6ec33fa44)>

### 개발 환경
- `Unity 2022.3.2f`

## 주요 기능
#### 시작씬
- 배경 움직임 활성화
- Start 버튼 (게임 시작)
- Exit 버튼 (게임 종료)

#### 메인씬 - 일반 맵
- 캐릭터 좌우로 이동(A, D or 좌, 우 방향키)
- 캐릭터 원거리 공격(Q), 피하기(X), 점프(Space bar)
- 몬스터와 피격시 플레이어 넉백
- 플레이어 최초 체력 3회 설정, 이후 몬스터와 1번 충돌 마다 체력-1
- 체력 전부 감소 시 게임오버씬
- 상점 구현, 맵 곳곳에서 얻은 재화로 체력 회복 아이템 구매
- 플레이어를 추적하며 따라오는 몬스터
- 보스몬스터로의 입장 포탈

#### 메인씬 - 보스맵
- 보스몬스터 출현
- 움직임 랜덤(?초에 ?걸음)
- 체력바 구현
- 체력 전부 감소 시 게임오버씬

#### 게임 클리어 씬
- Retry 버튼(시작씬으로 이동)
- Exit 버튼(게임 종료)

#### 게임 오버 씬
- Retry 버튼(시작씬으로 이동)
- Exit 버튼(게임 종료)

