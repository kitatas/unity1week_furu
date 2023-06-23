using Furu.Common.Data.Entity;
using Furu.Common.Domain.Repository;
using Furu.Common.Domain.UseCase;
using Furu.Common.Presentation.Controller;
using Furu.Common.Presentation.Presenter;
using Furu.Common.Presentation.View;
using VContainer;
using VContainer.Unity;

namespace Furu.Common.Installer
{
    public sealed class CommonInstaller : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            // Entity
            builder.Register<UserEntity>(Lifetime.Singleton);

            // Repository
            builder.Register<PlayFabRepository>(Lifetime.Singleton);
            builder.Register<SaveRepository>(Lifetime.Singleton);

            // UseCase
            builder.Register<LoadingUseCase>(Lifetime.Singleton);
            builder.Register<SceneUseCase>(Lifetime.Singleton);

            // Controller
            builder.Register<ExceptionController>(Lifetime.Singleton);

            // Presenter
            builder.RegisterEntryPoint<LoadingPresenter>();
            builder.RegisterEntryPoint<ScenePresenter>();

            // View
            builder.RegisterInstance<CrashView>(FindObjectOfType<CrashView>());
            builder.RegisterInstance<LoadingView>(FindObjectOfType<LoadingView>());
            builder.RegisterInstance<RetryView>(FindObjectOfType<RetryView>());
            builder.RegisterInstance<RebootView>(FindObjectOfType<RebootView>());
            builder.RegisterInstance<TransitionView>(FindObjectOfType<TransitionView>());
        }
    }
}