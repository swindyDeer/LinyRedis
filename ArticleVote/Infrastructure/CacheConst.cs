namespace ArticleVote.Infrastructure
{
    public static class CacheConst
    {
        /// <summary>
        /// 一个星期的秒数
        /// </summary>
        public const int OneWeekSeconds = 7 * 86400;

        /// <summary>
        /// 投票分数
        /// </summary>
        public const int VoteScore = 432;
        
        /// <summary>
        /// 文章id
        /// </summary>
        public const string ArticleId = "Id:ArticleId";
        
        /// <summary>
        /// 已投票
        /// </summary>
        public const string Voted = "Voted:{0}";

        /// <summary>
        /// 文章
        /// </summary>
        public const string Article = "Article:{0}";
        
        /// <summary>
        /// 评分
        /// </summary>
        public const string Score = "Score:";
        
        /// <summary>
        /// 时间
        /// </summary>
        public const string Time = "Time:";
    }
}