namespace ArticleVote.Service.Request
{
    /// <summary>
    /// 文章创建请求
    /// </summary>
    public class ArticleCreateRequest
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// 链接
        /// </summary>
        public string Link { get; set; }
        
        /// <summary>
        /// 用户
        /// </summary>
        public string User { get; set; }
    }
}