using etickets_web_app.Models;
using etickets_web_app.ViewModels;


namespace etickets_web_app.Mappers
{
    public static class ProducerViewModelMapper
    {
        public static Producer ToProducer(Producer producer, ProducerViewModel producerViewModel)
        {
            producer.FullName = producerViewModel.FullName;
            producer.ProfilePictureURL = producerViewModel.ProfilePictureURL;
            producer.Bio = producerViewModel.Bio;

            return producer;
        }

        public static ProducerViewModel ToViewModel(Producer producer)
        {
            return new ProducerViewModel();
        }
    }
}
