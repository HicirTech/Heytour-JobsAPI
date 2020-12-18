using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Model;
using WebApplication1.Repo;
using WebApplication1.ResourceParameters;

namespace WebApplication1.Service
{
    public interface IJobService
    {
        Task<IEnumerable<Heytour>> GetJobsList(JobsFilterParameters parameters);
        Task<Heytour> GetJobById(int jobId);
    }
    //构造函数注入常用于在服务构建上定义和获取服务依赖。如下
    //或者用于声明和获取服务对服务构造的依赖关系
    //如果要实现依赖注入就得调用依赖注入的接口来创建实例。
    public class JobService : IJobService
    {
        //将注入的依赖赋值给只读（readonly）的字段或属性
        //(为了防止在内部方法中意外地赋予其他值)。
        private readonly IJobRepo _jobRepo;
        //构造函数JobService将IJobRepo作为依赖注入到它的构造函数
        public JobService(IJobRepo jobRepo)
        {
            _jobRepo = jobRepo;
        }
        //然后在 GetJobsList方法内部使用这个依赖
        public async Task<IEnumerable<Heytour>> GetJobsList(JobsFilterParameters parameters)
        {
            IEnumerable<Heytour> jobs = null;


            var joblist = _jobRepo.GetJobs();
            if (parameters.IsActive.HasValue)
            {
                jobs = joblist.Where(m => m.IsActive == parameters.IsActive.Value).ToList();
            }
            else
            {
                jobs = joblist;
            }

            return jobs;

        }


        public async Task<Heytour> GetJobById(int jobId)
        {
            var job = await Task.Run(() => _jobRepo.GetJobs().FirstOrDefault(x => x.Id == jobId));

            return job;
        }


    }

}
