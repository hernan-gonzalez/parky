﻿using System;
using System.Collections.Generic;
using ParkyAPI.Models;
using ParkyAPI.Data;
using System.Linq;
using ParkyAPI.Repository.IRepository;
using Microsoft.EntityFrameworkCore;

namespace ParkyAPI.Repository
{
    public class TrailRepository : ITrailRepository
    {

        private readonly ApplicationDbContext _db;

        public TrailRepository(ApplicationDbContext db)
        {
            _db = db;

        }

        public bool CreateTrail(Trail trail)
        {
            _db.Trails.Add(trail);
            return Save();
        }

        public bool DeleteTrail(Trail trail)
        {
            _db.Trails.Remove(trail);
            return Save();
        }

        public Trail GetTrail(int trailId)
        {
            return _db.Trails.Include(c => c.NationalPark).FirstOrDefault(a => a.Id == trailId);

        }

        public ICollection<Trail> GetTrails()
        {
            return _db.Trails.Include(c => c.NationalPark).OrderBy(a => a.Name).ToList();
        }

        public ICollection<Trail> GetTrailsInNationalPark(int nationalParkId)
        {
            //Where(t=>t.NationalParkId==nationalParkId)
            return _db.Trails.Include(c=>c.NationalPark).Where(c => c.NationalParkId == nationalParkId).OrderBy(a => a.Name).ToList();
        }

        public bool TrailExists(string name)
        {
            bool value = _db.Trails.Any(a => a.Name.ToLower().Trim() == name.ToLower().Trim());
            return value;
        }

        public bool TrailExists(int trailId)
        {
            return _db.Trails.Any(a => a.Id == trailId);
        }

        public bool Save()
        {
            return _db.SaveChanges() >= 0 ? true : false;
        }

        public bool UpdateTrail(Trail trail)
        {
            _db.Trails.Update(trail);
            return Save();
        }

    }
}
