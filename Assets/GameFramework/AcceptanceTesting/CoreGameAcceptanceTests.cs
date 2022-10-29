using System.Collections;

namespace GameFramework.AcceptanceTesting
{
    public abstract class CoreGameAcceptanceTests<TTestSetup> : CoreGameAcceptanceTestBase<TTestSetup, CoreGameAcceptanceTests<TTestSetup>>
        where TTestSetup : TestSetup, new()
    {
        
    }
    
    public abstract class CoreGameAcceptanceTestBase<TTestSetup, TBasicMovementAcceptanceTest> : AcceptanceTestBase<TBasicMovementAcceptanceTest>
        where TTestSetup : TestSetup, new()
        where TBasicMovementAcceptanceTest : CoreGameAcceptanceTestBase<TTestSetup, TBasicMovementAcceptanceTest>
    {
        public abstract IEnumerator is_playing_the_core_game();
        public abstract IEnumerator is_given();
        public abstract IEnumerator moves_to_the_given_direction();
    }
}
